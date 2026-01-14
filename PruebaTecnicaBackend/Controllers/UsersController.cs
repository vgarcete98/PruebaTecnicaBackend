using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PruebaTecnicaBackend.Controllers
{
	[Route("users")]
	public class UsersController : Controller
    {

		[HttpGet("x")]
		public IActionResult ObtenerUsuarios()
		{

			try
			{
				return Ok();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
			}


		}


		[HttpPost("")]
		public IActionResult CrearUsuario()
		{

			try
			{
				return Ok();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
			}


		}


		[HttpGet("")]
		public IActionResult ObtenerUsuario()
		{

			try
			{
				return Ok();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
			}


		}

		[HttpPut("")]
		public IActionResult ActualizarUsuario()
		{

			try
			{
				return Ok();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return StatusCode(StatusCodes.Status500InternalServerError, new { error = ex.Message });
			}


		}


	}
}
