using FluentValidation;
using Movimentos.Domain.Entities;
using System.Collections.Generic;


namespace Movimentos.Domain.Interfaces
{
    public interface IBaseService<TEntity>
    {
        TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

        IList<TEntity> Get();

        List<MovimentosLanding> GetMovimentosLanding();

        Produto GetProdutoByCod(string cod);

        List<ProdutoCosif> GetProdutoCosifByProdutoCod(string produtoCod);
    }
}
