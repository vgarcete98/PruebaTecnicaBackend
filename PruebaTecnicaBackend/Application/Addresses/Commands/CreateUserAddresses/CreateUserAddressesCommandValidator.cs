using FluentValidation;
using PruebaTecnicaBackend.Data;
namespace PruebaTecnicaBackend.Application.Addresses.Commands.CreateUserAddresses
{
    public class CreateUserAddressesCommandValidator : AbstractValidator<CreateUserAddressesCommand>
    {

        //street, city, country: obligatorios 
        //userId debe existir, si no → 404.


        private readonly DbContextPTecnica _db;

        public CreateUserAddressesCommandValidator(DbContextPTecnica db)
        {
            _db = db;
            
            
            RuleFor(x => x.Street)
                .NotEmpty().WithMessage("La street es obligatorio");

            RuleFor(x => x.City)
                .NotEmpty().WithMessage("La ciudad es obligatorio");

            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("El country es obligatorio");



            RuleFor(x => x.Id)
                .MustAsync(UserExists)
                .WithMessage("El usuario no existe.");
        }



        private async Task<bool> UserExists(int id, CancellationToken ct)
        {
            bool usuario_encontrado = (await _db.Users.FindAsync(id) != null)? true: false;
            return usuario_encontrado;
        }


    }
}
