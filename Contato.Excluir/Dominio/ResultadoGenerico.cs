namespace Contato.Excluir.Dominio
{
    public class ResultadoGenerico
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; } = string.Empty;
        public object? Dados { get; set; }

        public ResultadoGenerico(bool sucesso, string mensagem, object? dados = null)
        {
            this.Sucesso = sucesso;
            this.Mensagem = mensagem;
            this.Dados = dados; 
        }
    }
}
