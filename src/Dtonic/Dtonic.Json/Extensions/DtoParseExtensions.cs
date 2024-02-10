using Dtonic.Dto.Base;
using Dtonic.Json.Exceptions;
using System.Text;
using System.Text.Json;

namespace Dtonic.Dto.Extensions;
public static class DtoParseExtensions
{
    private static readonly JsonReaderOptions _jsonReaderOptions = new JsonReaderOptions
    {
        AllowTrailingCommas = true,
        CommentHandling = JsonCommentHandling.Skip
    };

    public static T? Parse<T>(this string body) where T : IDtonic, new()
    {
        var dto = new T();
        return (T?)ProvisionFromString(dto, body);
    }

    public static async Task<IDtonic?> Parse(this IDtonic dto, Stream stream)
    {
        var s = await new StreamReader(stream).ReadToEndAsync();
        return ProvisionFromString(dto, s);
    }

    private static IDtonic? ProvisionFromString(IDtonic dto, string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        var jsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(value), _jsonReaderOptions);
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.StartObject)
        {
            dto.Parse(ref jsonReader);
            return dto;
        }

        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        throw new JsonStartsWithUnexpectedToken($"Json starts with unexpected token :{jsonReader.TokenType}");
    }
}
