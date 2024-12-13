using Contato.Atualizar.Dominio;
using Contato.Atualizar.Repositorios.ContatosRepositorios;

namespace Contato.Atualizar.Aplicacao
{
    public class ContatoComandos : IContatoComandos
    {
        private readonly IContatosComandosRepositorio _repositorio;

        public ContatoComandos(IContatosComandosRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public void Atualizar(DadosContato dadosContato)
        {
            _repositorio.Atualizar(dadosContato);
        }
    }
}
