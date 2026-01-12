using static PruebaTecnicaBackend.DbContextPTecnica;

using PruebaTecnicaBackend.Application.Addresses.Commands;

namespace PruebaTecnicaBackend.Application.Users.Commands
{
	public class Users
	{


		public int Id { get; set; }
		public string Name { get; set; }
		public int Email { get; set; }

		public int IsActive { get; set; }
		public string Password { get; set; }

		public List<Addresses> Posts { get; set; }

		public Users() { }
	}

}
