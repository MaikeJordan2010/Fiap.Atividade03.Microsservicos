using Contato.Atualizar.Dominio;
using Contato.Atualizar.Repositorios.Context;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Contato.Atualizar.Repositorios.ContatosRepositorios
{
    public class ContatosComandosRepositorio : IContatosComandosRepositorio
    {
        private readonly SqlConnection? _connection;

        public ContatosComandosRepositorio(IDbConection connection)
        {
            _connection = connection.ObterConexao();
        }

        public async Task Atualizar(DadosContato contato)
        {
            try
            {
                if (_connection != null)
                {
                    await _connection.OpenAsync();
                    _connection.Update<DadosContato>(contato);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally {
                _connection?.Close();
            }
        }
    }
}

