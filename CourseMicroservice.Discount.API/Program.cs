using CourseMicroservice.Discount.API;
using CourseMicroservice.Discount.API.Extensions;
using CourseMicroservice.Discount.API.Features.Discount;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerServices();
builder.Services.AddMongoOption();
builder.Services.AddDbServiceExt();
builder.Services.AddVersioning();
builder.Services.AddCommonServiceExt(typeof(DiscountAssembly));


var app = builder.Build();
app.AddDiscountEndpointExt(app.AddVersionSetExt());
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
	app.AddSwaggerExtension();
}

app.Run();

