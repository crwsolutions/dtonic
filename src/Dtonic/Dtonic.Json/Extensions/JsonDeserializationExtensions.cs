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

    public static JsonObject<T> ParseToJsonObject<T>(this ref Utf8JsonReader jsonReader) where T : class, IDtonic, new()
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            JsonObject<T> x = new(null);
            return x;
        }
        if (jsonReader.TokenType == JsonTokenType.StartObject)
        {
            var t = new T();
            t.Parse(ref jsonReader);
            JsonObject<T> x = new(t);
            return x;
        }
        throw new Exception("Unknown type");
    }

    public static JsonArrayOfObjects<T> ParseToJsonArrayOfObjects<T>(this ref Utf8JsonReader jsonReader) where T : class, IDtonic, new()
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            JsonArrayOfObjects<T> arrayWithNull = new(null);
            return arrayWithNull;
        }
        var lst = new List<object?>();
        if (jsonReader.TokenType == JsonTokenType.StartArray)
        {
            while (jsonReader.TokenType != JsonTokenType.EndArray)
            {
                if (jsonReader.Read() == false)
                {
                    break;
                }
                if (jsonReader.TokenType == JsonTokenType.StartObject)
                {
                    var t = new T();
                    if (t is IDtonic deserializable)
                    {
                        deserializable.Parse(ref jsonReader);
                        lst.Add(t);
                        continue;
                    }
                    throw new Exception("Unknown type");
                }
                else if (jsonReader.TokenType == JsonTokenType.Null)
                {
                    lst.Add(null);
                }
                else if (jsonReader.TokenType == JsonTokenType.String)
                {
                    lst.Add(jsonReader.GetString());
                }
                else if (jsonReader.TokenType == JsonTokenType.Number)
                {
                    lst.Add(jsonReader.GetDecimal());
                }
                else if (jsonReader.TokenType == JsonTokenType.True)
                {
                    lst.Add(true);
                }
                else if (jsonReader.TokenType == JsonTokenType.False)
                {
                    lst.Add(false);
                }
            }
        }
        IEnumerable<T> xx = lst.Cast<T>();
        JsonArrayOfObjects<T> x = new(xx);
        return x;
    }

    public static JsonArrayOfNumbers ParseToJsonArrayOfNumbers(this ref Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            JsonArrayOfNumbers arrayWithNull = new(null);
            return arrayWithNull;
        }
        var lst = new List<decimal?>();
        if (jsonReader.TokenType == JsonTokenType.StartArray)
        {
            while (jsonReader.TokenType != JsonTokenType.EndArray)
            {
                if (jsonReader.Read() == false)
                {
                    break;
                }
                if (jsonReader.TokenType == JsonTokenType.Null)
                {
                    lst.Add(null);
                }
                else if (jsonReader.TokenType == JsonTokenType.Number)
                {
                    lst.Add(jsonReader.GetDecimal());
                }
            }
        }

        return new(lst);
    }

    public static JsonArrayOfStrings ParseToJsonArrayOfStrings(this ref Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            JsonArrayOfStrings arrayWithNull = new(null);
            return arrayWithNull;
        }
        var lst = new List<string?>();
        if (jsonReader.TokenType == JsonTokenType.StartArray)
        {
            while (jsonReader.TokenType != JsonTokenType.EndArray)
            {
                if (jsonReader.Read() == false)
                {
                    break;
                }
                if (jsonReader.TokenType == JsonTokenType.Null)
                {
                    lst.Add(null);
                }
                else if (jsonReader.TokenType == JsonTokenType.String)
                {
                    lst.Add(jsonReader.GetString());
                }
            }
        }

        return new(lst);
    }

    public static JsonArrayOfBooleans ParseToJsonArrayOfBooleans(this ref Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            JsonArrayOfBooleans arrayWithNull = new(null);
            return arrayWithNull;
        }
        var lst = new List<bool?>();
        if (jsonReader.TokenType == JsonTokenType.StartArray)
        {
            while (jsonReader.TokenType != JsonTokenType.EndArray)
            {
                if (jsonReader.Read() == false)
                {
                    break;
                }
                if (jsonReader.TokenType == JsonTokenType.Null)
                {
                    lst.Add(null);
                }
                else if (jsonReader.TokenType == JsonTokenType.True)
                {
                    lst.Add(true);
                }
                else if (jsonReader.TokenType == JsonTokenType.False)
                {
                    lst.Add(false);
                }
            }
        }

        return new(lst);
    }
    public static JsonString ParseToJsonString(this ref Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            return new JsonString(null);
        }
        if (jsonReader.TokenType == JsonTokenType.String)
        {
            var s = jsonReader.GetString();
            return new JsonString(s);
        }
        throw new Exception("Unknown type");
    }

    public static JsonNumber ParseToJsonNumber(this ref Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            return new JsonNumber(null);
        }
        if (jsonReader.TokenType == JsonTokenType.Number)
        {
            var s = jsonReader.GetDecimal();
            return new JsonNumber(s);
        }
        throw new Exception("Unknown type");
    }

    public static JsonBoolean ParseToJsonBoolean(this ref Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            return new JsonBoolean(null);
        }
        if (jsonReader.TokenType == JsonTokenType.True)
        {
            return new JsonBoolean(true);
        }
        if (jsonReader.TokenType == JsonTokenType.False)
        {
            return new JsonBoolean(false);
        }
        throw new Exception("Unknown type");
    }
}
