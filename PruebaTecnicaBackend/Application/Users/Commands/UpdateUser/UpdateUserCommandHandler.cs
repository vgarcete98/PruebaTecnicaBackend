using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend.Application.Users.Commands.CreateUser;
using PruebaTecnicaBackend.Data;
using PruebaTecnicaBackend.Domain.Entities;

namespace PruebaTecnicaBackend.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler
    {


		private readonly DbContextPTecnica _context;

		public UpdateUserCommandHandler(DbContextPTecnica context)
		{
			_context = context;
		}

		public async Task<int> Handle(UpdateUserCommand command)
		{
			var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id);
			user.Name = command.Name;
			user.Email = command.Email;
			user.IsActive = (command.isActive == true )? 1: 0;

			_context.Users.Update(user);
			await _context.SaveChangesAsync();

			return user.Id;
		}
	}
}
