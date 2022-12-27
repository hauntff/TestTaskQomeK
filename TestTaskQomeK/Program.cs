using ChatApi.Hubs;
using TestTaskQomeK;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR(e=> { e.EnableDetailedErrors = true; });
builder.Services.AddTransient<ChatApi.Hubs.ChatHub>();
builder.Services.AddTransient<AuthApi.Controllers.AuthController>();
builder.Services.AddTransient<WeatherApi.Controllers.WeatherForecastController>();
builder.Services.AddAuthentication().AddJwtBearer();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapHub<ChatHub>("/chatHub"); });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
