using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend.Application.Users.Commands.CreateUser;
using PruebaTecnicaBackend.Data;
using PruebaTecnicaBackend.Domain.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace PruebaTecnicaBackend.Application.CurrencyConversion
{
	public class CurrencyConversionResult
	{
		public string fromCurrency { get; set; }
		public string toCurrency { get; set; }
		public decimal originalAmount { get; set; }
		public float convertedAmount { get; set; }
	}

	public class CurrencyConversionCommandHandler
    {

		private readonly DbContextPTecnica _context;

		public CurrencyConversionCommandHandler(DbContextPTecnica context)
		{
			_context = context;
		}

		public async Task<CurrencyConversionResult> Handle(CurrencyConversionCommand command)
		{
			var moneda1 = await _context.Currencies.Where(x => x.Code == command.fromCurrencyCode).FirstOrDefaultAsync();
			var moneda2 =  await _context.Currencies.Where(x => x.Code == command.toCurrencyCode).FirstOrDefaultAsync();

			decimal montoBase = command.amount* moneda1.RateToBase;

			float convertedAmount = ((float)(montoBase / moneda2.RateToBase));


			return new CurrencyConversionResult
			{
				fromCurrency = moneda1.Code,
				toCurrency = moneda2.Code,
				originalAmount = command.amount,
				convertedAmount = convertedAmount

			};
		}


	}
}
