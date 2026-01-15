using PruebaTecnicaBackend.Data;
using PruebaTecnicaBackend.Domain.Entities;

namespace PruebaTecnicaBackend.Application.Addresses.Commands.CreateUserAddresses
{
    public class CreateUserAddressesCommandHandler
    {
		private readonly DbContextPTecnica _context;

		public CreateUserAddressesCommandHandler(DbContextPTecnica context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreateUserAddressesCommand command)
		{
			var userAddress = new Address
			{
				Street = command.Street,
				City = command.City,
				Country = command.Country,
				ZipCode = command.ZipCode,
				UserId = command.UserId
			};

			_context.Addresses.Add(userAddress);
			await _context.SaveChangesAsync();

			return userAddress.Id;
		}
	}
}
