using Microsoft.Data.SqlClient;

namespace Contato.Excluir.Repositorios.Context
{
    public interface IDbConection
    {
        public SqlConnection? ObterConexao();

    }
}
