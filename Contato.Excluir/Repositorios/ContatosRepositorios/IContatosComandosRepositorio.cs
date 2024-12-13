using Contato.Excluir.Dominio;

namespace Contato.Excluir.Repositorios.ContatosRepositorios
{
    public interface IContatosComandosRepositorio
    {
        public Task Excluir(DadosContato contato);
    }
}
