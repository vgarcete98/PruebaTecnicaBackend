using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend.Application.Users.Queries.GetUsers;
using PruebaTecnicaBackend.Data;
using PruebaTecnicaBackend.Domain.Entities;

namespace PruebaTecnicaBackend.Application.Currencies.Queries.GetCurrencies
{
    public class GetCurrenciesQueryHandler
	{
		private readonly DbContextPTecnica _db;

		public GetCurrenciesQueryHandler(DbContextPTecnica db)
		{
			_db = db;
		}

		public async Task<List<Currency>> Handle(GetCurrenciesQuery query)
		{
			return await _db.Currencies.ToListAsync();
		}
	}
}
