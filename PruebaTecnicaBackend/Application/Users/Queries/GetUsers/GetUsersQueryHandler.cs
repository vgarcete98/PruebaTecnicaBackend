using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend.Data;
using PruebaTecnicaBackend.Domain.Entities;

namespace PruebaTecnicaBackend.Application.Users.Queries.GetUsers
{
	public class GetUsersQueryHandler
	{
		private readonly DbContextPTecnica _db;

		public GetUsersQueryHandler(DbContextPTecnica db)
		{
			_db = db;
		}

		public async Task<List<User>> Handle(GetUsersQuery query)
		{

			if (query.isActive == null)
			{
				return await _db.Users.ToListAsync();

			}else
			{
                return await _db.Users.Where( x=> x.IsActive == ((query.isActive.Value)? 1 : 0) ).ToListAsync();
            }
		}
	}
}
