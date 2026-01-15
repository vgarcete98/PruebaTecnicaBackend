using PruebaTecnicaBackend.Data;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend.Data;
using PruebaTecnicaBackend.Domain.Entities;
namespace PruebaTecnicaBackend.Application.Addresses.Commands.DeleteAddresses
{
    public class DeleteAddressesCommandHandler
	{

		private readonly DbContextPTecnica _context;

		public DeleteAddressesCommandHandler(DbContextPTecnica context)
		{
			_context = context;
		}

		public async Task<int> Handle(DeleteAddressesCommand command)
		{
			var address = await _context.Addresses.FirstOrDefaultAsync(x => x.Id == command.Id);

			_context.Addresses.Remove(address);
			await _context.SaveChangesAsync();

			return address.Id;
		}
	}
}
