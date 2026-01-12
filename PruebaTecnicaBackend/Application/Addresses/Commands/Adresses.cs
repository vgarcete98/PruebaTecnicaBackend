using PruebaTecnicaBackend.Application.Users.Commands;
namespace PruebaTecnicaBackend.Application.Addresses.Commands
{
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
