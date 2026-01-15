using MediatR;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend.Application.Users.Queries.GetUserById;
using PruebaTecnicaBackend.Data;
using PruebaTecnicaBackend.Domain.Entities;

namespace PruebaTecnicaBackend.Application.Addresses.Queries.GetAddressesUser
{
    public class GetAddressesUserQueryHandler
    {

		private readonly DbContextPTecnica _db;

		public GetAddressesUserQueryHandler(DbContextPTecnica db)
		{
			_db = db;
		}

		public async Task<List<Address>?> Handle(GetAddressesUserQuery query)
		{

			var addresses = await _db.Addresses.Where(x => x.UserId == query.Id).ToListAsync();
			return addresses;
		}
	}
}
