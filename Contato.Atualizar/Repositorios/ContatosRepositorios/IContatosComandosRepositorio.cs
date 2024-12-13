using Contato.Atualizar.Dominio;

namespace Contato.Atualizar.Repositorios.ContatosRepositorios
{
    public interface IContatosComandosRepositorio
    {
        public Task Atualizar(DadosContato contato);
    }
}
