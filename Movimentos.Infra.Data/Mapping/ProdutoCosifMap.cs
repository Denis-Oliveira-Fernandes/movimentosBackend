using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movimentos.Domain.Entities;

namespace Movimentos.Infra.Data.Mapping
{
    public class ProdutoCosifMap : IEntityTypeConfiguration<ProdutoCosif>
    {
        public void Configure(EntityTypeBuilder<ProdutoCosif> builder)
        {
            builder.ToTable("PRODUTO_COSIF");

            builder.Property(prop => prop.CodProduto)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("COD_PRODUTO")
                .HasColumnType("char(4)");

            builder.Property(prop => prop.CodCosif)
                .HasConversion(prop => prop, prop => prop)
                .HasColumnName("COD_COSIF")
                .HasColumnType("char(11)");

            builder.Property(prop => prop.CodClassificacao)
                .HasConversion(prop => prop, prop => prop)
                .HasColumnName("COD_CLASSIFICACAO")
                .HasColumnType("char(6)");

            builder.Property(prop => prop.Status)
                .HasConversion(prop => prop, prop => prop)
                .HasColumnName("STA_STATUS")
                .HasColumnType("char(1)");

        }
    }
}
