using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WeatherApi.Interfaces;
using WeatherApi.Models;
using WeatherApi.WeatherService;
namespace WeatherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
		private readonly IForecastRepository _forecastRepository;
		private readonly IWeatherService _weatherService;
		public WeatherForecastController(IForecastRepository forecastRepository, IWeatherService weatherService)
		{
			_forecastRepository = forecastRepository;
			_weatherService = weatherService;
		}

		[HttpGet("getWeather")]
		public async Task<City> City(string city)
		{
			// Consume the OpenWeatherAPI in order to bring Forecast data in our page.

			var root = await _forecastRepository.GetForecast(city);
			City cityWeather = new City();
			if (root != null)
			{
				cityWeather.Name = root.name;
				cityWeather.Humidity = root.main.humidity;
				cityWeather.Pressure = root.main.pressure;
				cityWeather.Temp = root.main.temp;
				cityWeather.Weather = root.weather[0].main;
				cityWeather.Wind = root.wind.speed;
			}
			await _weatherService.CreateAsync(cityWeather);
			return cityWeather;
		}
	}
}