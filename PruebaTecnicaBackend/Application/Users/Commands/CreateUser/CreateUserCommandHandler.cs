using PruebaTecnicaBackend.Data;
using PruebaTecnicaBackend.Domain.Entities;
using System.Security.Cryptography;
using System.Text;

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
				Email = command.Email,
				Password = HashPassword(GenerarCadenaAleatoria(12))
            };

			_context.Users.Add(user);
			await _context.SaveChangesAsync();

			return user.Id;
		}


        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }


        public static string GenerarCadenaAleatoria(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

    }
}
