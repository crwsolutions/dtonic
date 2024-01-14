using Dtonic.Json.Base;
using Dtonic.Json.Exceptions;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Dtonic.Json.Extensions;
public static class JsonSerializationExtensions
{
    public static string ToJsonString(this JsonNumber jsonNumber, [CallerArgumentExpression(nameof(jsonNumber))] string memberName = "") => !jsonNumber.IsSet ? "" : jsonNumber.IsNull ? $"\"{memberName}\":null" : $"\"{memberName}\":{jsonNumber.Value!.Value.ToString(CultureInfo.InvariantCulture)}";

    public static string ToJsonString(this JsonBoolean jsonBoolean, [CallerArgumentExpression(nameof(jsonBoolean))] string memberName = "")
    {
        return !jsonBoolean.IsSet
            ? ""
            : jsonBoolean.IsNull ? $"\"{memberName}\":null" : $"\"{memberName}\":{jsonBoolean.Value.ToString()!.ToLowerInvariant()}";
    }

    public static string ToJsonString(this JsonString jsonString, [CallerArgumentExpression(nameof(jsonString))] string memberName = "") => !jsonString.IsSet ? "" : jsonString.IsNull ? $"\"{memberName}\":null" : $"\"{memberName}\":\"{jsonString.Value}\"";

    public static string ToJsonString<T>(this JsonArray<T> array, [CallerArgumentExpression(nameof(array))] string memberName = "")
    {
        if (!array.IsSet)
        {
            return "";
        }

        if (array.IsNull)
        {
            return $"\"{memberName}\":null";
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
                bob.Append(',');
            }
            if (item is string)
            {
                bob.Append('"');
                bob.Append(item);
                bob.Append('"');
            }
            else if (item is float f)
            {
                bob.Append(f.ToString(CultureInfo.InvariantCulture));
            }
            else if (item is double d)
            {
                bob.Append(d.ToString(CultureInfo.InvariantCulture));
            }
            else if (item is decimal m)
            {
                bob.Append(m.ToString(CultureInfo.InvariantCulture));
            }
            else if (IsSimple(item.GetType()))
            {
                bob.Append(item);
            }
            else if (item is IJsonSerializable serializable)
            {
                bob.Append(serializable.ToJsonString());
            }
            else
            {
                throw DoesNotImplementIJsonSerializableException.Create(memberName, item.GetType());
            }
        }

        bob.Append(']');

        return $"\"{memberName}\":{bob}";
    }

    private static bool IsSimple(Type type)
    {
        return type.IsPrimitive
          || type.IsEnum;
    }

    public static string ToJsonString<T>(this JsonObject<T> jsonObject, [CallerArgumentExpression(nameof(jsonObject))] string memberName = "") where T : class
    {
        if (!jsonObject.IsSet)
        {
            return "";
        }

        return jsonObject.IsNull
            ? $"\"{memberName}\":null"
            : jsonObject.Value is IJsonSerializable serializable
            ? $"\"{memberName}\":{serializable.ToJsonString()}"
            : throw DoesNotImplementIJsonSerializableException.Create(memberName, jsonObject.Value.GetType());
    }
}
