using FluentValidation;

namespace PruebaTecnicaBackend.Application.Users.Commands.CreateUser
{
	public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
	{
		public CreateUserCommandValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty().WithMessage("El nombre es obligatorio");

			RuleFor(x => x.Email)
				.NotEmpty().WithMessage("El email es obligatorio")
				.EmailAddress().WithMessage("Formato de email inválido");
		}
	}
}
