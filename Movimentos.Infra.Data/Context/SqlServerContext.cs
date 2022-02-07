using Microsoft.EntityFrameworkCore;
using Movimentos.Domain.Entities;
using Movimentos.Infra.Data.Mapping;

namespace Movimentos.Infra.Data.Context
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        public DbSet<Movimento> MOVIMENTO_MANUAL { get; set; }

        public DbSet<Produto> PRODUTO { get; set; }

        public DbSet<ProdutoCosif> PRODUTO_COSIF { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movimento>(new MovimentoMap().Configure);
            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
            modelBuilder.Entity<ProdutoCosif>(new ProdutoCosifMap().Configure);
        }
    }
}
