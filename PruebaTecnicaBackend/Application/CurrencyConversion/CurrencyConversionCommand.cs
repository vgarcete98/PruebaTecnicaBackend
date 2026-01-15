namespace PruebaTecnicaBackend.Application.CurrencyConversion
{
    public class CurrencyConversionCommand
    {

		public string fromCurrencyCode { get; set; } = null!;

		public string toCurrencyCode { get; set; } = null!;

		public int amount { get; set; }
	}
}
