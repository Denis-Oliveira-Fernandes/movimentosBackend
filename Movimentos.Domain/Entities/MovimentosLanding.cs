using System.ComponentModel.DataAnnotations;

namespace Movimentos.Domain.Entities
{
    public class MovimentosLanding : BaseEntity
    {
        [Key]
        public decimal DataMes { get; set; }
        public decimal DataAno { get; set; }
        public string CodProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal NumeroLancamento { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
    }
}
