using Dtonic.Json.Base;
using Dtonic.Json.Exceptions;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace Dtonic.Json.Extensions;
public static class JsonSerializationExtensions
{
    public static string Stringify(this JsonNumber jsonNumber, [CallerArgumentExpression(nameof(jsonNumber))] string memberName = "") => !jsonNumber.IsSet ? "" : jsonNumber.IsNull ? $"\"{memberName}\":null" : $"\"{memberName}\":{jsonNumber.Value!.Value.ToString(CultureInfo.InvariantCulture)}";

    public static string Stringify(this JsonBoolean jsonBoolean, [CallerArgumentExpression(nameof(jsonBoolean))] string memberName = "")
    {
        return !jsonBoolean.IsSet
            ? ""
            : jsonBoolean.IsNull ? $"\"{memberName}\":null" : $"\"{memberName}\":{jsonBoolean.Value.ToString()!.ToLowerInvariant()}";
    }

    public static string Stringify(this JsonString jsonString, [CallerArgumentExpression(nameof(jsonString))] string memberName = "") => !jsonString.IsSet ? "" : jsonString.IsNull ? $"\"{memberName}\":null" : $"\"{memberName}\":\"{jsonString.Value}\"";

    public static string Stringify<T>(this JsonArrayOfObjects<T> array, [CallerArgumentExpression(nameof(array))] string memberName = "") where T : class, IDtonic, new()
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
            bob.AppendSupportedType(item, memberName);
        }

        bob.Append(']');

        return $"\"{memberName}\":{bob}";
    }

    public static string Stringify(this JsonArrayOfNumbers array, [CallerArgumentExpression(nameof(array))] string memberName = "")
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
            if (item is null)
            {
                bob.Append("null");
            }
            else
            {
                bob.Append(item.Value.ToString(CultureInfo.InvariantCulture));
            }
        }

        bob.Append(']');

        return $"\"{memberName}\":{bob}";
    }

    public static string Stringify(this JsonArrayOfStrings array, [CallerArgumentExpression(nameof(array))] string memberName = "")
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
            if (item is null)
            {
                bob.Append("null");
            }
            else
            {
                bob.Append('"');
                bob.Append(item);
                bob.Append('"');
            }
        }

        bob.Append(']');

        return $"\"{memberName}\":{bob}";
    }

    public static string Stringify(this JsonArrayOfBooleans array, [CallerArgumentExpression(nameof(array))] string memberName = "")
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
            if (item is null)
            {
                bob.Append("null");
            }
            else
            {
                bob.Append(item.Value.ToString().ToLower());
            }
        }

        bob.Append(']');

        return $"\"{memberName}\":{bob}";
    }

    public static string Stringify<T>(this JsonDictionary<T> dictionary, [CallerArgumentExpression(nameof(dictionary))] string memberName = "")
    {
        if (!dictionary.IsSet)
        {
            return "";
        }

        if (dictionary.IsNull)
        {
            return $"\"{memberName}\":null";
        }
        var first = true;
        var bob = new StringBuilder();
        bob.Append('[');
        foreach (var item in dictionary.Value)
        {
            if (first)
            {
                first = false;
            }
            else
            {
                bob.Append(',');
            }
            bob.Append("{\"");
            bob.Append(item.Key);
            bob.Append("\":");
            bob.AppendSupportedType(item.Value, memberName);
            bob.Append('}');
        }

        bob.Append(']');

        return $"\"{memberName}\":{bob}";
    }
    
    public static string Stringify<T>(this JsonObject<T> jsonObject, [CallerArgumentExpression(nameof(jsonObject))] string memberName = "") where T : class
    {
        if (!jsonObject.IsSet)
        {
            return "";
        }

        return jsonObject.IsNull
            ? $"\"{memberName}\":null"
            : jsonObject.Value is IDtonic serializable
            ? $"\"{memberName}\":{serializable.Stringify()}"
            : throw DoesNotImplementIJsonSerializableException.Create(memberName, jsonObject.Value.GetType());
    }

    private static void AppendSupportedType<T>(this StringBuilder bob, T value, string memberName)
    {
        if (value == null)
        {
            bob.Append("null");
        }
        else if (value is string)
        {
            bob.Append('"');
            bob.Append(value);
            bob.Append('"');
        }
        else if (value is float f)
        {
            bob.Append(f.ToString(CultureInfo.InvariantCulture));
        }
        else if (value is double d)
        {
            bob.Append(d.ToString(CultureInfo.InvariantCulture));
        }
        else if (value is decimal m)
        {
            bob.Append(m.ToString(CultureInfo.InvariantCulture));
        }
        else if (IsSimple(value.GetType()))
        {
            bob.Append(value);
        }
        else if (value is IDtonic serializable)
        {
            bob.Append(serializable.Stringify());
        }
        else
        {
            throw DoesNotImplementIJsonSerializableException.Create(memberName, value.GetType());
        }
    }
    
    private static bool IsSimple(Type type)
    {
        return type.IsPrimitive
          || type.IsEnum;
    }
}
