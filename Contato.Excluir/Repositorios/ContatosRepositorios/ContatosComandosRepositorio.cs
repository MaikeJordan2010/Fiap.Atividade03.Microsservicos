using Contato.Excluir.Dominio;
using Contato.Excluir.Repositorios.Context;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Contato.Excluir.Repositorios.ContatosRepositorios
{
    public class ContatosComandosRepositorio : IContatosComandosRepositorio
    {
        private readonly SqlConnection? _connection;

        public ContatosComandosRepositorio(IDbConection connection)
        {
            _connection = connection.ObterConexao();
        }

        public async Task Excluir(DadosContato contato)
        {
            try
            {
                if (_connection != null)
                {
                    await _connection.OpenAsync();
                    _connection.Delete<DadosContato>(contato);
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

