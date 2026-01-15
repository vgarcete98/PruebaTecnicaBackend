using PruebaTecnicaBackend.Application.Users.Commands.UpdateUser;
using PruebaTecnicaBackend.Data;
using Microsoft.EntityFrameworkCore;

namespace PruebaTecnicaBackend.Application.Addresses.Commands.UpdateAddresses
{
    public class UpdateAddressesCommandHandler
    {
		private readonly DbContextPTecnica _context;

		public UpdateAddressesCommandHandler(DbContextPTecnica context)
		{
			_context = context;
		}

		public async Task<int> Handle(UpdateAddressesCommand command)
		{
			var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == command.Id);
			address.Street = command.Street;
			address.City = command.City;
			address.ZipCode = command.ZipCode;
			address.Country = command.Country;

			_context.Addresses.Update(address);
			
			await _context.SaveChangesAsync();

			return address.Id;
		}
	}
}
