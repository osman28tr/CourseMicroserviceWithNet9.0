
using CourseMicroservice.Catalog.API;
using CourseMicroservice.Catalog.API.Extensions;
using CourseMicroservice.Catalog.API.Features.Categories;
using CourseMicroservice.Catalog.API.Options;
using CourseMicroservice.Catalog.API.Repositories;
using CourseMicroservice.Shared.Extensions;
using MongoDB.Driver;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddMongoOption();

builder.Services.AddDbServiceExt();

var app = builder.Build();
//Endpoints
app.AddCategoryEndpointExt();
builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
