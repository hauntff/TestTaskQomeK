using ChatApi.Hubs;
using Microsoft.OpenApi.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ChatHub>();
builder.Services.AddSwaggerGen(options => { options.SwaggerDoc("v1", new OpenApiInfo { Title = "ChatApi", Version = "v1" }); });
builder.Services
  .AddSignalR()
  .AddStackExchangeRedis("localhost:6379");
builder.Services.AddSignalR(e => { e.EnableDetailedErrors = true; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store.Product.Api v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapHub<ChatHub>("/chatHub");    
app.UseEndpoints(endpoints => { endpoints.MapControllers(); endpoints.MapHub<ChatHub>("/chatHub"); });
app.MapControllers();
app.Run();
