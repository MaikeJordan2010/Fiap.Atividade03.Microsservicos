using Contato.Cadastrar.Dominio;

namespace Contato.Cadastrar.Repositorios.ContatosRepositorios
{
    public interface IContatosComandosRepositorio
    {
        public Task Inserir(DadosContato contato);
    }
}
