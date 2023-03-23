using CapitalPlacement;
using CapitalPlacement.Core.Context;
using CapitalPlacement.Core.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config

var appSettingsSection = configuration.GetSection("Settings");
var appSettings = appSettingsSection.Get<AppSettings>();
var db = appSettings.DB;
var dbName = appSettings.DBName;

// Add DB context
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseCosmos(db, databaseName: dbName), ServiceLifetime.Transient);

builder.Services.AddCustomServices();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CapitalPlacement.Api", Version = "v1" });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CapitalPlacement.Api v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();
