using System;
using System.ComponentModel.DataAnnotations;

namespace Movimentos.Domain.Entities
{
    public class Movimento : BaseEntity
    {
        [Key]
        public decimal DataMes { get; set; }
        public decimal DataAno { get; set; }
        public decimal NumeroLancamento { get; set; }
        public string CodProduto { get; set; }
        public string CodCosif { get; set; }
        public string Descricao { get; set; }
        public DateTime DataMovimento { get; set; }
        public string CodUsuario { get; set; }
        public decimal Valor { get; set; }
    }
}
