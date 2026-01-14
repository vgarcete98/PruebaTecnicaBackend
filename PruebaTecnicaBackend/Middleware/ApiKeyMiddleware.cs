namespace PruebaTecnicaBackend.Middleware
{
	public class ApiKeyMiddleware
	{
		private readonly RequestDelegate _next;
		private const string APIKEYHEADER = "X-API-KEY";

		public ApiKeyMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task InvokeAsync(HttpContext context, IConfiguration config)
		{
			if (!context.Request.Headers.TryGetValue(APIKEYHEADER, out var extractedApiKey))
			{
				context.Response.StatusCode = 401; // Unauthorized
				await context.Response.WriteAsync("");
				return;
			}

			var apiKey = config.GetValue<string>("ApiKey");

			if (!apiKey.Equals(extractedApiKey))
			{
				context.Response.StatusCode = 401; // Si no es correcta
				await context.Response.WriteAsync("");
				return;
			}

			await _next(context);
		}
	}
}
