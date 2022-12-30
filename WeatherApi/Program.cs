using MongoDB.Driver;
using WeatherApi.Controllers;
using WeatherApi.Data;
using WeatherApi.Interfaces;
using WeatherApi.Models;
using WeatherApi.Repos;
using WeatherApi.WeatherService;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.Configure<WeatherDbSettings>(builder.Configuration.GetSection("WeatherDatabase"));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IForecastRepository, ForecastRepository>();

builder.Services.AddSingleton<IWeatherService, WeatherService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
