using WeatherApi.Models;

namespace WeatherApi.Interfaces
{
	public interface IWeatherService
	{
		Task<List<City>> GetAsync();
		Task<City?> GetAsync(string name);

		Task CreateAsync(City newCity);

		Task UpdateAsync(string name, City updatedCity);

		 Task RemoveAsync(string name);
	}
}
