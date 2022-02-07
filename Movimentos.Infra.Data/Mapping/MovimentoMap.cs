using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movimentos.Domain.Entities;

namespace Movimentos.Infra.Data.Mapping
{
    public class MovimentoMap : IEntityTypeConfiguration<Movimento>
    {
        public void Configure(EntityTypeBuilder<Movimento> builder)
        {
            builder.ToTable("MOVIMENTO_MANUAL");

            builder.Property(prop => prop.DataMes)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("DAT_MES")
                .HasColumnType("numeric(2,0)");

            builder.Property(prop => prop.DataAno)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("DAT_ANO")
                .HasColumnType("numeric(4, 0)");

            builder.Property(prop => prop.NumeroLancamento)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("NUM_LANCAMENTO")
                .HasColumnType("numeric(18, 0)");

            builder.Property(prop => prop.CodProduto)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("COD_PRODUTO")
                .HasColumnType("char(4)");

            builder.Property(prop => prop.CodCosif)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("COD_COSIF")
                .HasColumnType("char(11)");

            builder.Property(prop => prop.Descricao)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("DES_DESCRICAO")
                .HasColumnType("varchar(50)");

            builder.Property(prop => prop.DataMovimento)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("DAT_MOVIMENTO")
                .HasColumnType("smalldatetime");

            builder.Property(prop => prop.CodUsuario)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("COD_USUARIO")
                .HasColumnType("varchar(15)");

            builder.Property(prop => prop.Valor)
                .HasConversion(prop => prop, prop => prop)
                .IsRequired()
                .HasColumnName("VAL_VALOR")
                .HasColumnType("numeric(18, 2)");


        }
    }
}
