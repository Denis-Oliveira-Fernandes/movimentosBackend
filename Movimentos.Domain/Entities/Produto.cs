using System.ComponentModel.DataAnnotations;

namespace Movimentos.Domain.Entities
{
    public class Produto : BaseEntity
    {
        [Key]
        public string CodProduto { get; set; }
        public string DesProduto { get; set; }
        public string Status { get; set; }
    }
}
