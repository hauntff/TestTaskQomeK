using AuthApi.Data;
using AuthApi.Repos;
using AuthApi.Services;
using ChatApi.Hubs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TestTaskQomeK;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddSignalR(e=> { e.EnableDetailedErrors = true; });
var connStr = builder.Configuration.GetConnectionString("LocalConnectionString");
if (string.IsNullOrWhiteSpace(connStr))
	throw new ArgumentNullException(connStr);

builder.Services.AddTransient<ChatHub>();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapHub<ChatHub>("/chatHub"); });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Chat}/{action=Index}");
app.Run();
