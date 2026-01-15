namespace PruebaTecnicaBackend.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommand
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }

		public Boolean isActive { get; set; }
	}
}
