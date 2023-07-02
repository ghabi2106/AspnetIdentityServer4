using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile($"ocelot.json");

var authenticationProviderKey = "IdentityApiKey";

// NUGET - Microsoft.AspNetCore.Authentication.JwtBearer
builder.Services.AddAuthentication()
 .AddJwtBearer(authenticationProviderKey, x =>
 {
     x.Authority = "https://localhost:5005"; // IDENTITY SERVER URL
                                             //x.RequireHttpsMetadata = false;
     x.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateAudience = false
     };
 });

// Add services to the container.
builder.Services.AddOcelot();

var app = builder.Build();

app.MapControllers();

await app.UseOcelot();

app.Run();
