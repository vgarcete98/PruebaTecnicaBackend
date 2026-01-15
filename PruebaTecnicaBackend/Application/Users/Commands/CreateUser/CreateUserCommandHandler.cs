using PruebaTecnicaBackend.Data;
using PruebaTecnicaBackend.Domain.Entities;

namespace PruebaTecnicaBackend.Application.Users.Commands.CreateUser
{
	public class CreateUserCommandHandler
	{
		private readonly DbContextPTecnica _context;

		public CreateUserCommandHandler(DbContextPTecnica context)
		{
			_context = context;
		}

		public async Task<int> Handle(CreateUserCommand command)
		{
			var user = new User
			{
				Name = command.Name,
				Email = command.Email
			};

			_context.Users.Add(user);
			await _context.SaveChangesAsync();

			return user.Id;
		}
	}
}
