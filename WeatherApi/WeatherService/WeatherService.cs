using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WeatherApi.Data;
using WeatherApi.Interfaces;
using WeatherApi.Models;

namespace WeatherApi.WeatherService
{
	public class WeatherService : IWeatherService
	{
		private readonly IMongoCollection<City> _weatherCollection;
		public WeatherService(IOptions<WeatherDbSettings> options)
		{
			var mongoClient = new MongoClient(options.Value.ConnectionString);
			var mongoDatabase = mongoClient.GetDatabase(options.Value.DatabaseName);
			_weatherCollection = mongoDatabase.GetCollection<City>(options.Value.WeatherCollectionName);
		}
		public async Task<List<City>> GetAsync() =>
		await _weatherCollection.Find(_ => true).ToListAsync();

		public async Task<City?> GetAsync(string name) =>
			await _weatherCollection.Find(x => x.Name == name).FirstOrDefaultAsync();

		public async Task CreateAsync(City newCity) =>
			await _weatherCollection.InsertOneAsync(newCity);

		public async Task UpdateAsync(string name, City updatedCity) =>
			await _weatherCollection.ReplaceOneAsync(x => x.Name == name, updatedCity);

		public async Task RemoveAsync(string name) =>
			await _weatherCollection.DeleteOneAsync(x => x.Name == name);
	}
}
