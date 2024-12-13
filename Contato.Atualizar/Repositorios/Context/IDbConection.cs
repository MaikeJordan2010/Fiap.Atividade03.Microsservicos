using Microsoft.Data.SqlClient;

namespace Contato.Atualizar.Repositorios.Context
{
    public interface IDbConection
    {
        public SqlConnection? ObterConexao();

    }
}
