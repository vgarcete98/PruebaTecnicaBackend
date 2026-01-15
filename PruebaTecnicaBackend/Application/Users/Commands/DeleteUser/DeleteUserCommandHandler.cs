using PruebaTecnicaBackend.Data;
using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBackend.Data;
using PruebaTecnicaBackend.Domain.Entities;
namespace PruebaTecnicaBackend.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler
    {


		private readonly DbContextPTecnica _context;

		public DeleteUserCommandHandler(DbContextPTecnica context)
		{
			_context = context;
		}

		public async Task<int> Handle(DeleteUserCommand command)
		{
			var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == command.Id);

			_context.Users.Remove(user);
			await _context.SaveChangesAsync();

			return user.Id;
		}
	}
}
