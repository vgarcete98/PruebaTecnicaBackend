
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace PruebaTecnicaBackend
{
    public class DbContextPTecnica : DbContext
    {


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(@"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True;ConnectRetryCount=0");
		}




		public class Currencies
		{

			public int Id { get; set; }
			public string Code { get; set; }
			public string Name { get; set; }

			public decimal RateToBase { get; set; }

			public Currencies() { }
		}


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



		public class Addresses
		{

			public int Id { get; set; }
			public int UUserId { get; set; }
			public Users User { get; set; }

			public string Street { get; set; }

			public int City { get; set; }

			public int Country { get; set; }


			public int ZipCode { get; set; }

		}

	}
}
