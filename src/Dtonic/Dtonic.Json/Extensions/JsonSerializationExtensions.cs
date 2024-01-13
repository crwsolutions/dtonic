using Dtonic.Json.Base;
using System.Runtime.CompilerServices;
using System.Text;

namespace Dtonic.Json.Extensions;
public static class JsonSerializationExtensions
{
    public static string ToJsonString(this JsonNumber jsonNumber, [CallerArgumentExpression(nameof(jsonNumber))] string memberName = "")
    {
        if (!jsonNumber.IsSet)
        {
            return "";
        }

        return jsonNumber.IsNull ? $"{memberName}:null" : $"{memberName}:{jsonNumber.Value}";
    }

    public static string ToJsonString(this JsonBoolean jsonBoolean, [CallerArgumentExpression(nameof(jsonBoolean))] string memberName = "")
    {
        if (!jsonBoolean.IsSet)
        {
            return "";
        }

        return jsonBoolean.IsNull ? $"{memberName}:null" : $"{memberName}:{jsonBoolean.Value.ToString()!.ToLowerInvariant()}";
    }

    public static string ToJsonString(this JsonString jsonString, [CallerArgumentExpression(nameof(jsonString))] string memberName = "")
    {
        if (!jsonString.IsSet)
        {
            return "";
        }

        return jsonString.IsNull ? $"{memberName}:null" : $"{memberName}:\"{jsonString.Value}\"";
    }

    public static string ToJsonString<T>(this JsonArray<T> array, [CallerArgumentExpression(nameof(array))] string memberName = "")
    {
        if (!array.IsSet)
        {
            return "";
        }

        if (array.IsNull)
        {
            return $"{memberName}:null";
        }

        var bob = new StringBuilder();
        _ = bob.Append('[');
        _ = bob.Append(string.Join(",", array.Value!));
        _ = bob.Append(']');

        return $"{memberName}:{bob}";
    }

    public static string ToJsonString<T>(this JsonObject<T> jsonObject, [CallerArgumentExpression(nameof(jsonObject))] string memberName = "") where T : class
    {
        if (!jsonObject.IsSet)
        {
            return "";
        }

        if (jsonObject.IsNull)
        {
            return $"{memberName}:null";
        }

        return jsonObject.Value is IJsonSerializable serializable
            ? $"{memberName}:{serializable.ToJsonString()}"
            : throw new ArgumentException($"{memberName} does not implement {nameof(IJsonSerializable)}");
    }
}
