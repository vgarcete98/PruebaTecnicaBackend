using Microsoft.EntityFrameworkCore;
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

		public async Task<User> Handle(CreateUserAddressesCommand command)
		{

            var user = await _context.Users.FindAsync(command.Id);
            int maxId = await _context.Addresses.MaxAsync(u => (int?)u.Id) ?? 0;

            if (user != null)
			{
				var userAddress = new Address
				{
					Id = maxId + 1,
                    Street = command.Street,
					City = command.City,
					Country = command.Country,
					ZipCode = command.ZipCode,
					UserId = command.UserId,
					User = user
				};

				_context.Addresses.Add(userAddress);
				await _context.SaveChangesAsync();

				return user;

			}else
			{
				return null;

            }

		}
	}
}
