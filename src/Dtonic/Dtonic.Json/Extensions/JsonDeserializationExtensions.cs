using Dtonic.Json.Base;
using System.Text;
using System.Text.Json;

namespace Dtonic.Json.Extensions;
public static class JsonDeserializationExtensions
{
    public static T? Parse<T>(this string s) where T : IDtonic, new()
    {
        var options = new JsonReaderOptions
        {
            AllowTrailingCommas = true,
            CommentHandling = JsonCommentHandling.Skip
        };
        var jsonReader = new Utf8JsonReader(Encoding.UTF8.GetBytes(s), options);
        return jsonReader.ParseJsonDeserializable<T>();
    }

    public static T? ParseJsonDeserializable<T>(this ref Utf8JsonReader jsonReader) where T : IDtonic, new()
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            return default;
        }
        if (jsonReader.TokenType == JsonTokenType.StartObject)
        {
            var t = new T();
            t.Parse(ref jsonReader);
            return t;
        }
        throw new Exception("Unknown type");
    }
}
