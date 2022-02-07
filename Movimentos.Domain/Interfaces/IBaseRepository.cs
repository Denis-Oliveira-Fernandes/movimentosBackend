using Movimentos.Domain.Entities;
using System.Collections.Generic;

namespace Movimentos.Domain.Interfaces
{
    public interface IBaseRepository<TEntity>
    {
        void Insert(TEntity obj);

        void Insert(Movimento obj);

        IList<TEntity> Select();

        Produto SelectProdutoByCod(string cod);

        List<ProdutoCosif> SelectProdutoCosifByProdutoCod(string produtoCod);

        decimal SelectLastLancamento(decimal datMes, decimal datAno);

        List<MovimentosLanding> SelectLandingMovimentos();
    }
}
