using Contato.Excluir.Dominio;
using Contato.Excluir.Repositorios.ContatosRepositorios;

namespace Contato.Excluir.Aplicacao
{
    public class ContatoComandos : IContatoComandos
    {
        private readonly IContatosComandosRepositorio _repositorio;

        public ContatoComandos(IContatosComandosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public void Excluir(DadosContato dadosContato)
        {
            _repositorio.Excluir(dadosContato);
        }
    }
}
