using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaBackend.Application.Currencies.Commands.CreateCurrencies;
using PruebaTecnicaBackend.Application.Currencies.Queries.GetCurrencies;
using PruebaTecnicaBackend.Application.CurrencyConversion;
using PruebaTecnicaBackend.Application.Users.Commands.CreateUser;
using PruebaTecnicaBackend.Application.Users.Queries.GetUsers;

namespace PruebaTecnicaBackend.Controllers
{
    [ApiController]

    public class CurrencyController : ControllerBase
    {

		private readonly IServiceProvider _serviceProvider;

		public CurrencyController(IServiceProvider serviceProvider)
		{


			_serviceProvider = serviceProvider;
		}

		[HttpGet("currencies")]
		public async Task<IActionResult> ListarMonedas()
		{

			try
			{
				var handler = _serviceProvider.GetRequiredService<GetCurrenciesQueryHandler>();
				var currencies = await handler.Handle(new GetCurrenciesQuery());
				return Ok(currencies);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
			}


		}


		[HttpPost("currencies")]
		public async Task<IActionResult> CrearMoneda([FromBody] CreateCurrenciesCommand command)
		{

			try
			{
				var handler = _serviceProvider.GetRequiredService<CreateCurrenciesCommandHandler>();
				var id = await handler.Handle(command);
				return Ok(id);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
			}


		}

		[HttpPost("currency/convert")]
		public async Task<IActionResult> ConvertirMonedas([FromBody] CurrencyConversionCommand command)
		{

			try
			{
				var handler = _serviceProvider.GetRequiredService<CurrencyConversionCommandHandler>();
				var resultado = await handler.Handle(command);
				return Ok(resultado);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
			}


		}





	}
}
