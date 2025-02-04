using IdentityService.Infrastructure.Extensions;
using IdentityService.Application.Extensions;
using IdentityService.API.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
//add and validate options at startup
builder.Services.AddOptions(builder.Configuration);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddControllers();

builder.Services.AddAuthorization();
builder.Services.AddInfrastructure(options =>
{
    options.DatabaseOptions = builder.Configuration.GetDatabaseOptions();
    options.RepositoryLifetime = ServiceLifetime.Scoped;
    options.AuthenticationServicesLifetime = ServiceLifetime.Scoped;
    options.JwtOptions = builder.Configuration.GetJwtOptions();
});
builder.Services.AddApplication(options =>
{
    options.ServiceLifetime = ServiceLifetime.Scoped;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Theme = ScalarTheme.BluePlanet;
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
