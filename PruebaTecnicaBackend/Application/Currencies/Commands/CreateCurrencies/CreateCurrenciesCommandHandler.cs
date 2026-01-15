using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend.Application.Users.Commands.CreateUser;
using PruebaTecnicaBackend.Data;
using PruebaTecnicaBackend.Domain.Entities;

namespace PruebaTecnicaBackend.Application.Currencies.Commands.CreateCurrencies
{
    public class CreateCurrenciesCommandHandler
    {

		private readonly DbContextPTecnica _context;

		public CreateCurrenciesCommandHandler(DbContextPTecnica context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreateCurrenciesCommand command)
		{
			int maxId = await _context.Currencies.MaxAsync(u => (int?)u.Id) ?? 0;
			var currency = new Currency
			{
				Id = maxId + 1,
				Code = command.Code,
				Name = command.Name,
				RateToBase = command.RateToBase,
			};

			_context.Currencies.Add(currency);
			await _context.SaveChangesAsync();

			return currency.Id;
		}
	}
}
