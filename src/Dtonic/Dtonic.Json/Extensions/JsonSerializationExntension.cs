using Dtonic.Json.Base;
using System.Runtime.CompilerServices;
using System.Text;

namespace Dtonic.Json.Extensions;
public static class JsonSerializationExntension
{
    public static string ToJsonString<T>(this JsonTypeBase<T> jsonType, [CallerArgumentExpression(nameof(jsonType))] string memberName = "")
    {
        if (!jsonType.IsSet)
        {
            return "";
        }

        if (jsonType.IsNull)
        {
            return $"{memberName}:null";
        }

        return $"{memberName}:{jsonType.Value}";
    }

    public static string ToJsonString<T>(JsonArray<T> array, [CallerArgumentExpression(nameof(array))] string memberName = "") 
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
        bob.Append('[');
        bob.Append(string.Join(",", array.Value!));
        bob.Append(']');

        return $"{memberName}:{bob}";
    }

    public static string ToJsonString<T>(JsonObject<T> jsonObject, [CallerArgumentExpression(nameof(jsonObject))] string memberName = "") where T : class
    {
        if (!jsonObject.IsSet)
        {
            return "";
        }

        if (jsonObject.IsNull)
        {
            return $"{memberName}:null";
        }

        if (jsonObject.Value is IJsonSerializable serializable)
        {
            return $"{memberName}:{serializable.ToJsonString()}";
        }

        throw new ArgumentException($"{memberName} does not implement {nameof(IJsonSerializable)}");
    }
}
