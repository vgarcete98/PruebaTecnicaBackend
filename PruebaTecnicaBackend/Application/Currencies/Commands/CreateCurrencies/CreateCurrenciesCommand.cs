namespace PruebaTecnicaBackend.Application.Currencies.Commands.CreateCurrencies
{
    public class CreateCurrenciesCommand
    {
		public string Code { get; set; } = null!;

		public string Name { get; set; } = null!;

		public decimal RateToBase { get; set; }
	}
}
