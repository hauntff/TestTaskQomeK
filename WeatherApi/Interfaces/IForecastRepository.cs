using WeatherApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApi.Interfaces
{
    public interface IForecastRepository
    {
		Task<Root> GetForecast(string city);

	}
}
