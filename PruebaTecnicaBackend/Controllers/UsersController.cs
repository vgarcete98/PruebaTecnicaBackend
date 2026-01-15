using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaBackend.Application.Addresses.Commands.CreateUserAddresses;
using PruebaTecnicaBackend.Application.Addresses.Queries.GetAddressesUser;
using PruebaTecnicaBackend.Application.Users.Commands.CreateUser;
using PruebaTecnicaBackend.Application.Users.Commands.DeleteUser;
using PruebaTecnicaBackend.Application.Users.Commands.UpdateUser;
using PruebaTecnicaBackend.Application.Users.Queries.GetUserById;
using PruebaTecnicaBackend.Application.Users.Queries.GetUsers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace PruebaTecnicaBackend.Controllers
{
	[Route("users")]
	public class UsersController : Controller
    {
		private readonly IServiceProvider _serviceProvider;
		public UsersController(IServiceProvider serviceProvider) {


			_serviceProvider = serviceProvider;
		}

		[HttpGet]
		public async Task<IActionResult> ObtenerUsuarios()
		{

			try
			{
				var handler = _serviceProvider.GetRequiredService<GetUsersQueryHandler>();
				var users = await handler.Handle(new GetUsersQuery());
				return Ok(users);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
			}


		}


		[HttpPost]
		public async Task<IActionResult> CrearUsuario([FromBody] CreateUserCommand command)
		{

			try
			{
				var handler = _serviceProvider.GetRequiredService<CreateUserCommandHandler>();
				var id = await handler.Handle(command);
				return Ok(id);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
			}


		}


		[HttpGet("{id}")]
		public async Task<IActionResult> ObtenerUsuario(int id)
		{

			try
			{
				var handler = _serviceProvider.GetRequiredService<GetUserByIdQueryHandler>();
				var user = await handler.Handle(new GetUserByIdQuery(id));
				return user == null ? NotFound() : Ok(user);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
			}


		}



		[HttpGet("{id}/addresses")]
		public async Task<IActionResult> ObtenerDireccionesUsuario(int id)
		{

			try
			{
				//var handler = _serviceProvider.GetRequiredService<GetAddressesUserQuery>();
				//var userAddresses = await handler.Handle(new GetAddressesUserQuery(id));
				//return userAddresses == null ? NotFound() : Ok(userAddresses);
				return Ok();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
			}


		}


		[HttpPost("{id}/addresses")]
		public async Task<IActionResult> CrearDireccionUsuario(int id, [FromBody] CreateUserAddressesCommand command)
		{

			try
			{
				var handler = _serviceProvider.GetRequiredService<CreateUserAddressesCommandHandler>();
				var direcciones = await handler.Handle(command);
				return Ok(direcciones);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
			}


		}




		[HttpPut("{id}")]
		public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] UpdateUserCommand command)
		{

			try
			{
				command.Id = id;
				var handler = _serviceProvider.GetRequiredService<UpdateUserCommandHandler>();
				var ok = await handler.Handle(command);
				return Ok();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
			}


		}


		[HttpDelete("{id}")]
		public async Task<IActionResult> BorrarUsuario(int id, [FromBody] UpdateUserCommand command)
		{
			var handler = _serviceProvider.GetRequiredService<DeleteUserCommandHandler>();
			await handler.Handle(new DeleteUserCommand { Id = id });
			return NoContent();
		}


	}
}
