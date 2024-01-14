using Dtonic.Json.Base;
using System.Runtime.CompilerServices;
using System.Text;

namespace Dtonic.Json.Extensions;
public static class JsonSerializationExtensions
{
    public static string ToJsonString(this JsonNumber jsonNumber, [CallerArgumentExpression(nameof(jsonNumber))] string memberName = "") => !jsonNumber.IsSet ? "" : jsonNumber.IsNull ? $"{memberName}:null" : $"{memberName}:{jsonNumber.Value}";

    public static string ToJsonString(this JsonBoolean jsonBoolean, [CallerArgumentExpression(nameof(jsonBoolean))] string memberName = "")
    {
        return !jsonBoolean.IsSet
            ? ""
            : jsonBoolean.IsNull ? $"{memberName}:null" : $"{memberName}:{jsonBoolean.Value.ToString()!.ToLowerInvariant()}";
    }

    public static string ToJsonString(this JsonString jsonString, [CallerArgumentExpression(nameof(jsonString))] string memberName = "") => !jsonString.IsSet ? "" : jsonString.IsNull ? $"{memberName}:null" : $"{memberName}:\"{jsonString.Value}\"";

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
        var first = true;
        var bob = new StringBuilder();
        bob.Append('[');
        foreach (var item in array.Value) 
        {
            if (first)
            { 
                first = false;
            }
            else 
            {
                bob.Append(", ");
            }
            if (IsSimple(item.GetType()))
            {
                bob.Append(item);
            }
            else if (item is IJsonSerializable serializable)
            {
                bob.Append(serializable.ToJsonString());
            }
            else 
            {
                throw new Exception("InvalidJsonType");
            }
        }
        
        bob.Append(']');

        return $"{memberName}:{bob}";
    }

    private static bool IsSimple(Type type)
    {
        return type.IsPrimitive
          || type.IsEnum
          || type.Equals(typeof(string))
          || type.Equals(typeof(decimal));
    }

    public static string ToJsonString<T>(this JsonObject<T> jsonObject, [CallerArgumentExpression(nameof(jsonObject))] string memberName = "") where T : class
    {
        if (!jsonObject.IsSet)
        {
            return "";
        }

        return jsonObject.IsNull
            ? $"{memberName}:null"
            : jsonObject.Value is IJsonSerializable serializable
            ? $"{memberName}:{serializable.ToJsonString()}"
            : throw new ArgumentException($"{memberName} does not implement {nameof(IJsonSerializable)}");
    }
}
