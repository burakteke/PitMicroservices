using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"configuration.{builder.Environment.EnvironmentName.ToLower()}.json").AddEnvironmentVariables();

builder.Services.AddAuthentication().AddJwtBearer("GatewayAuthenticationScheme", options =>
{
    options.Authority = builder.Configuration["IdentityServerURL"];
    options.Audience = "resource_gateway";
    options.RequireHttpsMetadata = false; //uygulamay� https yapmad�k diye. Https uygulamalar i�in gerek yok.
});
builder.Services.AddOcelot();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseOcelot().Wait();

app.Run();
