using Movimentos.Domain.Entities;
using Movimentos.Domain.Interfaces;
using Movimentos.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;

namespace Movimentos.Infra.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly SqlServerContext _sqlServerContext;

        public BaseRepository(SqlServerContext mySqlContext)
        {
            _sqlServerContext = mySqlContext;
        }

        public void Insert(TEntity obj)
        {
            _sqlServerContext.Set<TEntity>().Add(obj);
            _sqlServerContext.SaveChanges();
        }

        public void Insert(Movimento obj)
        {
            _sqlServerContext.Set<Movimento>().Add(obj);
            _sqlServerContext.SaveChanges();
        }

        public IList<TEntity> Select() =>
            _sqlServerContext.Set<TEntity>().ToList();

        public Produto SelectProdutoByCod(string cod) =>
            _sqlServerContext.Set<Produto>().Where(_ => _.CodProduto == cod)
                                            .FirstOrDefault();
        public List<ProdutoCosif> SelectProdutoCosifByProdutoCod(string cod) =>
            _sqlServerContext.Set<ProdutoCosif>().Where(_ => _.CodProduto == cod)
                                                 .ToList();

        public decimal SelectLastLancamento(decimal datMes, decimal datAno) =>
            _sqlServerContext.Set<Movimento>().Where(_ => _.DataMes == datMes && _.DataAno == datAno)
                                              .OrderByDescending(_ => _.NumeroLancamento)
                                              .Take(1)
                                              .Select(_ => _.NumeroLancamento)
                                              .FirstOrDefault();

        public List<MovimentosLanding> SelectLandingMovimentos()
        {
            return _sqlServerContext
                        .Set<Movimento>()
                        .Join(_sqlServerContext.PRODUTO,
                                  m => m.CodProduto,
                                  p => p.CodProduto,
                                  (m, p) => new { p1 = p, m1 = m })
                                           .Select(mp => new MovimentosLanding
                                                         {
                                                              DataMes = mp.m1.DataMes,
                                                              DataAno = mp.m1.DataAno,
                                                              CodProduto = mp.m1.CodProduto,
                                                              DescricaoProduto = mp.p1.DesProduto,
                                                              NumeroLancamento = mp.m1.NumeroLancamento,
                                                              Descricao = mp.m1.Descricao,
                                                              Valor = mp.m1.Valor
                                                          })
                                           .OrderBy(_ => _.DataAno)
                                           .ThenBy(_ => _.DataMes)
                                           .ThenBy(_ => _.NumeroLancamento)
                                           .ToList();
        }
    }
}
