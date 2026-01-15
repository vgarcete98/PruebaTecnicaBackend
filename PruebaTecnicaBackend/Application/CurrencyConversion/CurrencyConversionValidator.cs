using FluentValidation;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace PruebaTecnicaBackend.Application.CurrencyConversion
{
    public class CurrencyConversionValidator : AbstractValidator<CurrencyConversionCommand>
    {

        private readonly DbContextPTecnica _db;
        public CurrencyConversionValidator(DbContextPTecnica db)
        {
            _db = db;

            //amount > 0
            //fromCurrencyCode y toCurrencyCode deben existir en Currencies. 

            RuleFor(x => x.amount)
                .GreaterThan(0).WithMessage("El monto tiene que ser mayor a 0");

            RuleFor(x => x.fromCurrencyCode)
                .MustAsync(fromCurrencyCodeExists)
                .WithMessage("La fromCurrencyCodeExists no existe.");


            RuleFor(x => x.toCurrencyCode)
                .MustAsync(toCurrencyCodeExists)
                .WithMessage("La fromCurrencyCodeExists no existe.");
        }



        private async Task<bool> fromCurrencyCodeExists(string code, CancellationToken ct)
        {
            bool fromcurrencie_encontrado = (await _db.Currencies.Where(x => x.Code == code).FirstOrDefaultAsync() != null) ? true : false;
            return fromcurrencie_encontrado;
        }

        private async Task<bool> toCurrencyCodeExists(string code, CancellationToken ct)
        {
            bool tocurrencie_encontrado = (await _db.Currencies.Where(x => x.Code == code).FirstOrDefaultAsync() != null) ? true : false;
            return tocurrencie_encontrado;
        }
    }
}
