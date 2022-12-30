using BlogApi.Data;
using BlogApi.Interfaces;
using BlogApi.Repos;
using BlogApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connStr = builder.Configuration.GetConnectionString("LocalConnectionString");
if (string.IsNullOrWhiteSpace(connStr))
	throw new ArgumentNullException(connStr);
builder.Services.AddDbContext<BlogDbContext>(options =>
{
	options.UseNpgsql(connStr);
	options.EnableSensitiveDataLogging();
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IBlogService, BlogService>();
builder.Services.AddTransient<IBlogRepository, BlogRepository>();
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
