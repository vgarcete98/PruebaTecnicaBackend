namespace PruebaTecnicaBackend.Application.Currencies.Commands
{

	public class Currencies
	{

		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }

		public decimal RateToBase { get; set; }

		public Currencies() { }
	}
}
