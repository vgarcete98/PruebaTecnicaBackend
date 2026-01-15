using PruebaTecnicaBackend.Data;
using PruebaTecnicaBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnicaBackend.Application.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler
    {

		private readonly DbContextPTecnica _db;

		public GetUserByIdQueryHandler(DbContextPTecnica db)
		{
			_db = db;
		}

		public async Task<User?> Handle(GetUserByIdQuery query)
		{
			return await _db.Users.FindAsync(query.Id);
		}
	}
}
