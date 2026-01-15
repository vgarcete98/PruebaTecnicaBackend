namespace PruebaTecnicaBackend.Application.Addresses.Commands.UpdateAddresses
{
    public class UpdateAddressesCommand
	{
		public int Id { get; set; }

		public string Street { get; set; } = null!;

		public string City { get; set; } = null!;

		public string Country { get; set; } = null!;

		public string? ZipCode { get; set; }
	}
}
