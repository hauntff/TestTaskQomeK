using AuthApi.Controllers;
using AuthApi.Data;
using AuthApi.Interfaces;
using AuthApi.Repos;
using AuthApi.Services;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connStr = builder.Configuration.GetConnectionString("LocalConnectionString");
if (string.IsNullOrWhiteSpace(connStr))
    throw new ArgumentNullException(connStr);
builder.Services.AddDbContext<AuthDbContext>(options =>
{
    options.UseNpgsql(connStr);
    options.EnableSensitiveDataLogging();
});
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

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
