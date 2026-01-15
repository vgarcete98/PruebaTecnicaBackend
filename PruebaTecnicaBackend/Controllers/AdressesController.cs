using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaBackend.Application.Addresses.Commands.DeleteAddresses;
using PruebaTecnicaBackend.Application.Addresses.Commands.UpdateAddresses;

namespace PruebaTecnicaBackend.Controllers
{
    [ApiController]
    [Route("addresses")]
	public class AdressesController : ControllerBase
    {
		private readonly IServiceProvider _serviceProvider;
		public AdressesController(IServiceProvider serviceProvider)
		{


			_serviceProvider = serviceProvider;
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> EliminarDireccion(int id, [FromBody] DeleteAddressesCommand command)
		{
			var handler = _serviceProvider.GetRequiredService<DeleteAddressesCommandHandler>();
			await handler.Handle(new DeleteAddressesCommand { Id = id });
			return NoContent();
		}


		[HttpPut("{id}")]
		public async Task<IActionResult> ModificarDireccion(int id, [FromBody] UpdateAddressesCommand command)
		{
			var handler = _serviceProvider.GetRequiredService<UpdateAddressesCommandHandler>();
			await handler.Handle(new UpdateAddressesCommand { Id = id });
			return NoContent();
		}

	}
}
