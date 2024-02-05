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
    c.MapType<DtoObject<ChildDto>>(() => new OpenApiSchema { Type = "object" });

    c.MapType<DtoArrayOfObjects<ChildDto>>(() => new OpenApiSchema { Type = "array", Items = new OpenApiSchema { Type = "object" } });
    c.MapType<DtoArrayOfNumbers>(() => new OpenApiSchema { Type = "array", Items = new OpenApiSchema { Type = "number" } });
    c.MapType<DtoArrayOfStrings>(() => new OpenApiSchema { Type = "array", Items = new OpenApiSchema { Type = "string" } });
    c.MapType<DtoArrayOfBooleans>(() => new OpenApiSchema { Type = "array", Items = new OpenApiSchema { Type = "boolean" } });

    c.MapType<DtoDictionaryOfObjects<ChildDto>>(() => new OpenApiSchema { Type = "object", AdditionalProperties = new OpenApiSchema { Type = "object" } });
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
