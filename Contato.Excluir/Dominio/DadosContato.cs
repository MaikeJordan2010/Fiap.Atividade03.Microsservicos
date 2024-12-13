using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Contato.Excluir.Dominio
{
    [Table("TabContatos")]
    public class DadosContato
    {
        [Key]
        public string? Guid { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? DDD { get; set; }
        public string? Telefone { get; set; }
        public string? Estado { get; set; }
        public string? Municipio { get; set; }
    }
}
