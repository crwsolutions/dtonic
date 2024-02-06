using Dtonic.Dto;
using Dtonic.Dto.Example.Web.Dto;
using Dtonic.Json.Example.Web.DocumentFilters;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.DocumentFilter<ChildDtoDocumentFilter>();
    c.MapType<DtoString>(() => new OpenApiSchema { Type = "string" });
    c.MapType<DtoNumber>(() => new OpenApiSchema { Type = "number" });
    c.MapType<DtoBoolean>(() => new OpenApiSchema { Type = "boolean" });
    c.MapType<DtoObject<ChildDto>>(() => new OpenApiSchema { Type = "object", Reference = new OpenApiReference()
    {
        Type = ReferenceType.Schema,
        Id = nameof(ChildDto)
    }
    });

    c.MapType<DtoArrayOfStrings>(() => new OpenApiSchema { Type = "array", Items = new OpenApiSchema { Type = "string" } });
    c.MapType<DtoArrayOfNumbers>(() => new OpenApiSchema { Type = "array", Items = new OpenApiSchema { Type = "number" } });
    c.MapType<DtoArrayOfBooleans>(() => new OpenApiSchema { Type = "array", Items = new OpenApiSchema { Type = "boolean" } });
    c.MapType<DtoArrayOfObjects<ChildDto>>(() => new OpenApiSchema { Type = "array", Items = new OpenApiSchema { Type = "object",
        Reference = new OpenApiReference()
        {
            Type = ReferenceType.Schema,
            Id = nameof(ChildDto)
        }
    } });

    c.MapType<DtoDictionaryWithStrings>(() => new OpenApiSchema { Type = "object", AdditionalProperties = new OpenApiSchema { Type = "string" } });
    c.MapType<DtoDictionaryWithNumbers>(() => new OpenApiSchema { Type = "object", AdditionalProperties = new OpenApiSchema { Type = "number" } });
    c.MapType<DtoDictionaryWithBooleans>(() => new OpenApiSchema { Type = "object", AdditionalProperties = new OpenApiSchema { Type = "boolean" } });
    c.MapType<DtoDictionaryWithObjects<ChildDto>>(() => new OpenApiSchema { Type = "object", AdditionalProperties = new OpenApiSchema { Type = "object",
        Reference = new OpenApiReference()
        {
            Type = ReferenceType.Schema,
            Id = nameof(ChildDto)
        }
    } });

    c.MapType<DtoDictionaryWithArrayOfBooleans>(() => new OpenApiSchema { Type = "object", AdditionalProperties = new OpenApiSchema { Type = "array", Items = new OpenApiSchema { Type = "boolean" } } });
    c.MapType<DtoDictionaryWithArrayOfNumbers>(() => new OpenApiSchema { Type = "object", AdditionalProperties = new OpenApiSchema { Type = "array", Items = new OpenApiSchema { Type = "number" } } });
    c.MapType<DtoDictionaryWithArrayOfStrings>(() => new OpenApiSchema { Type = "object", AdditionalProperties = new OpenApiSchema { Type = "array", Items = new OpenApiSchema { Type = "string" } } });
    c.MapType<DtoDictionaryWithArrayOfObjects<ChildDto>>(() => new OpenApiSchema { Type = "object", AdditionalProperties = new OpenApiSchema { Type = "array", Items = new OpenApiSchema { Type = "object",
        Reference = new OpenApiReference()
        {
            Type = ReferenceType.Schema,
            Id = nameof(ChildDto)
        }
    } } });
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
