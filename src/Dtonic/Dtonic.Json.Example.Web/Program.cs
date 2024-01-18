using Dtonic.Json;
using Dtonic.Json.Example.Web.Dto;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.MapType<JsonString>(() => new OpenApiSchema { Type = "string" });
    c.MapType<JsonNumber>(() => new OpenApiSchema { Type = "number" });
    c.MapType<JsonBoolean>(() => new OpenApiSchema { Type = "boolean" });
    c.MapType<JsonArrayOfObjects<PersonDto>>(() => new OpenApiSchema { Type = "array" });
    c.MapType<JsonObject<AddressDto>>(() => new OpenApiSchema { Type = "object" });
});

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
