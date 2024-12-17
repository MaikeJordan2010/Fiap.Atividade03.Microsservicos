using Contato.Atualizar.Aplicacao;
using Contato.Atualizar.Dominio;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Contato.Atualizar
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConnectionFactory _factory;
        private readonly IContatoComandos _contatoComandos;
        private const string _nomeFila = "contato.fila.atualizar";

        public Worker(ILogger<Worker> logger, IContatoComandos contatoComandos)
        {
            _logger = logger;
            _contatoComandos = contatoComandos;
            _factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest",

            };
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                using var connection = await _factory.CreateConnectionAsync();
                using (var channel = await connection.CreateChannelAsync())
                {
                    await channel.ExchangeDeclareAsync(exchange: _nomeFila, type: ExchangeType.Fanout);
                    QueueDeclareOk queueDeclareResult = await channel.QueueDeclareAsync();
                    await channel.QueueBindAsync(queue: _nomeFila, exchange: _nomeFila, routingKey: _nomeFila);

                    Console.WriteLine($"OBTENDO DADOS PARA ATUALIZAÇÃO: ");

                    while (!stoppingToken.IsCancellationRequested)
                    {
                        var consumer = new AsyncEventingBasicConsumer(channel);
                        consumer.ReceivedAsync += async (modal, resp) =>
                        {
                            byte[] body = resp.Body.ToArray();
                            var message = Encoding.UTF8.GetString(body);

                            if (string.IsNullOrEmpty(message))
                                await Task.CompletedTask;

                            var contato = JsonConvert.DeserializeObject<DadosContato>(message);

                            if (contato != null)
                            {
                                Console.WriteLine($"ENVIANDO REGISTRO: {contato.Guid}  DE NOME: {contato.Nome} PARA ATUALIZAÇÃO!");
                                _contatoComandos.Atualizar(contato!);
                            }

                           await Task.CompletedTask;
                        };

                        await channel.BasicConsumeAsync(_nomeFila, autoAck: true, consumer: consumer);

                        await Task.Delay(1000, stoppingToken);
                    }
                }
            }
            catch (Exception ex) { 
                Console.WriteLine(ex.ToString() );
            }
        }

    }
}
