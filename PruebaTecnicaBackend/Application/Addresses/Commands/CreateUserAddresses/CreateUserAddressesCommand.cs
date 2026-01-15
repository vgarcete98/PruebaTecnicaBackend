namespace PruebaTecnicaBackend.Application.Addresses.Commands.CreateUserAddresses
{
    public class CreateUserAddressesCommand
    {
		public int Id { get; set; }

		public int UserId { get; set; }

		public string Street { get; set; } = null!;

		public string City { get; set; } = null!;

		public string Country { get; set; } = null!;

		public string? ZipCode { get; set; }

	}
}
