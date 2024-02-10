using Dtonic.Dto.Base;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Net.Mime;
using System.Text;

namespace Dtonic.Json.Example.Web.ModelBinder;

public class DtonicOutputFormatter : TextOutputFormatter
{
    private static readonly MediaTypeHeaderValue _jsonHeader = new(MediaTypeNames.Application.Json);

    public DtonicOutputFormatter()
    {
        SupportedMediaTypes.Add(_jsonHeader);
        SupportedEncodings.Add(Encoding.UTF8);
        SupportedEncodings.Add(Encoding.Unicode);
    }

    protected override bool CanWriteType(Type? type) => type?.GetInterface(nameof(IDtonic)) is not null;

    public override async Task WriteResponseBodyAsync(
        OutputFormatterWriteContext context, Encoding selectedEncoding)
    {
        if (context.Object is not IDtonic dto)
        {
            throw new Exception("Type is incorrect");
        }

        await context.HttpContext.Response.WriteAsync(dto.Stringify(), selectedEncoding);
    }
}
