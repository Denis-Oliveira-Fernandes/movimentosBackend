using FluentValidation;
using Movimentos.Domain.Entities;
using Movimentos.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Movimentos.Service.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>
        {
            Validate(obj, Activator.CreateInstance<TValidator>());

            switch(obj.GetType().Name)
            {
                case "Movimento":
                    Movimento movimento = (Movimento)Convert.ChangeType(obj, typeof(Movimento));
                    CreateMovimento(movimento);
                    return obj;
                default:
                    _baseRepository.Insert(obj);
                    return obj;

            }
        }

        private void CreateMovimento(Movimento movimento)
        {
            var lastLancamento = GetLastLancamento(movimento.DataMes, movimento.DataAno);
            movimento.NumeroLancamento = lastLancamento <= 0 ? 1 : lastLancamento + 1;
            movimento.DataMovimento = DateTime.Now;
            movimento.CodUsuario = "TESTE";

            _baseRepository.Insert(movimento);
        }

        public Movimento Add2<MovimentoValidator>(Movimento movimento) where MovimentoValidator : AbstractValidator<Movimento>
        {
            ValidateMovimento(movimento, Activator.CreateInstance<AbstractValidator<Movimento>>());
            var lastLancamento = GetLastLancamento(movimento.DataMes, movimento.DataAno);
            movimento.NumeroLancamento = lastLancamento <= 0 ? 1 : lastLancamento + 1;
            movimento.DataMovimento = DateTime.Now;
            movimento.CodUsuario = "TESTE";

            _baseRepository.Insert(movimento);
            return movimento;
        }

        public IList<TEntity> Get() => _baseRepository.Select();

        public List<MovimentosLanding> GetMovimentosLanding() => _baseRepository.SelectLandingMovimentos();

        public Produto GetProdutoByCod(string cod) => _baseRepository.SelectProdutoByCod(cod);

        public List<ProdutoCosif> GetProdutoCosifByProdutoCod(string produtoCod) => _baseRepository.SelectProdutoCosifByProdutoCod(produtoCod);

        public decimal GetLastLancamento(decimal datMes, decimal datAno) => _baseRepository.SelectLastLancamento(datMes, datAno);

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }

        private void ValidateMovimento(Movimento movimento, AbstractValidator<Movimento> validator)
        {
            if (movimento == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(movimento);
        }
    }
}
