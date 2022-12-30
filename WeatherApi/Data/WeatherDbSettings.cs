namespace WeatherApi.Data
{
	public class WeatherDbSettings
	{
		public string ConnectionString { get; set; } = null!;

		public string DatabaseName { get; set; } = null!;

		public string WeatherCollectionName { get; set; } = null!;
	}
}
