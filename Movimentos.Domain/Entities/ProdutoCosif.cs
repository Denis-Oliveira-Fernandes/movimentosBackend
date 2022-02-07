using System.ComponentModel.DataAnnotations;

namespace Movimentos.Domain.Entities
{
    public class ProdutoCosif : BaseEntity
    {
        public string CodProduto { get; set; }
        [Key]
        public string CodCosif { get; set; }
        public string CodClassificacao { get; set; }
        public string Status { get; set; }
    }
}
