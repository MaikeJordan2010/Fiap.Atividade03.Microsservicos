using Contato.Excluir.Dominio;

namespace Contato.Excluir.Aplicacao
{
    public interface IContatoComandos
    {
        public void Excluir(DadosContato dadosContato);
    }
}
