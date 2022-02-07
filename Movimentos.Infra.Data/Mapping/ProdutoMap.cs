using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movimentos.Domain.Entities;

namespace Movimentos.Infra.Data.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("PRODUTO");

            builder.Property(prop => prop.CodProduto)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("COD_PRODUTO")
                .HasColumnType("char(4)");

            builder.Property(prop => prop.DesProduto)
                .HasConversion(prop => prop, prop => prop)
                .HasColumnName("DES_PRODUTO")
                .HasColumnType("varchar(30)");

            builder.Property(prop => prop.Status)
                .HasConversion(prop => prop, prop => prop)
                .HasColumnName("STA_STATUS")
                .HasColumnType("char(1)");

        }
    }
}
