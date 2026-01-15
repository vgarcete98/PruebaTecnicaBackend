using FluentValidation;

namespace PruebaTecnicaBackend.Application.Currencies.Commands.CreateCurrencies
{
    public class CreateCurrenciesCommandValidator : AbstractValidator<CreateCurrenciesCommand>
    {



        public CreateCurrenciesCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El Name es obligatorio");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("El Code es obligatorio");


            RuleFor(x => x.RateToBase)
                .GreaterThan(0).WithMessage("El RateToBase tiene que ser mayor a 0");
        }
    }
}
