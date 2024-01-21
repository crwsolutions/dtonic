using Dtonic.Dto;
using Dtonic.Dto.Example.Web.Dto;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.MapType<DtoString>(() => new OpenApiSchema { Type = "string" });
    c.MapType<DtoNumber>(() => new OpenApiSchema { Type = "number" });
    c.MapType<DtoBoolean>(() => new OpenApiSchema { Type = "boolean" });
    c.MapType<DtoArrayOfObjects<PersonDto>>(() => new OpenApiSchema { Type = "array" });
    c.MapType<DtoObject<AddressDto>>(() => new OpenApiSchema { Type = "object" });
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
