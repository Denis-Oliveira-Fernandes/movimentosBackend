using FluentValidation;
using Movimentos.Domain.Entities;

namespace Movimentos.Service.Validators
{
    public class MovimentoValidator : AbstractValidator<Movimento>
    {
        public MovimentoValidator()
        {
            RuleFor(c => c.DataMes)
                .NotNull().WithMessage("Campo dataMes não pode ser nulo.")
                .NotEmpty().WithMessage("Campo dataMes não pode ser vazio.");

            RuleFor(c => c.DataAno)
                .NotNull().WithMessage("Campo dataAno não pode ser nulo.")
                .NotEmpty().WithMessage("Campo dataAno não pode ser vazio.");

            RuleFor(c => c.CodProduto)
                .NotNull().WithMessage("Campo codProduto não pode ser nulo.")
                .NotEmpty().WithMessage("Campo codProduto não pode ser vazio.");


            RuleFor(c => c.CodCosif)
                .NotNull().WithMessage("Campo codCosif não pode ser nulo.")
                .NotEmpty().WithMessage("Campo codCosif não pode ser vazio.");

            RuleFor(c => c.Descricao)
                .NotNull().WithMessage("Campo descricao não pode ser nulo.")
                .NotEmpty().WithMessage("Campo descricao não pode ser vazio.");

            RuleFor(c => c.Valor)
                .NotNull().WithMessage("Campo valor não pode ser nulo.")
                .NotEmpty().WithMessage("Campo valor não pode ser vazio.");

        }
    }
}
