using Dtonic.Dto.Example.Web.Dto;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Dtonic.Json.Example.Web.DocumentFilters;

public class ChildDtoDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        context.SchemaGenerator.GenerateSchema(typeof(ChildDto), context.SchemaRepository);
    }
}
