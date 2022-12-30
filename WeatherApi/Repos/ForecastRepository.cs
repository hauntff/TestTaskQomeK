using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApi.Interfaces;
using WeatherApi.Models;
using Microsoft.VisualBasic;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace WeatherApi.Repos
{

	public class ForecastRepository : IForecastRepository
    {
		private readonly IConfiguration _configuration;

		public ForecastRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<Root> GetForecast(string city)
        {
            string key = _configuration.GetSection("ApiKey:Key").Value;
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&APPID={key}";
			var client = new RestClient(url);
			var request = new RestRequest(url, Method.Get);

            var root = await client.ExecuteAsync(request);
            if (root.IsSuccessful)
            {
				var content = JsonConvert.DeserializeObject<JToken>(root.Content);
				return content.ToObject<Root>();
            }
            return null;
        }
    }
}
