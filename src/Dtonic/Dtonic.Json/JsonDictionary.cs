using Dtonic.Json.Base;
using Dtonic.Json.Exceptions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.Json;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonDictionary<T> : JsonTypeBase<IDictionary<string, T>>
{
    private JsonDictionary() { }

    public JsonDictionary(IDictionary<string, T>? value) : base(value)
    {
    }

    public static JsonDictionary<T> Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(JsonDictionary<T>));
    public override string Stringify()
    {
        if (IsNull)
        {
            return "null";
        }
        var first = true;
        var bob = new StringBuilder();
        bob.Append('[');
        foreach (var item in Value)
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
            AppendSupportedType(bob, item.Value);
            bob.Append('}');
        }

        bob.Append(']');

        return bob.ToString();
    }

    private static void AppendSupportedType<T>(StringBuilder bob, T value)
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
            throw DoesNotImplementIJsonSerializableException.Create("?", value.GetType());
        }
    }

    private static bool IsSimple(Type type)
    {
        return type.IsPrimitive
          || type.IsEnum;
    }
    public override void Parse(ref Utf8JsonReader jsonReader) => throw new NotImplementedException();

    public static implicit operator JsonDictionary<T>(Dictionary<string, T>? items) => new((IDictionary<string, T>?)items);
}
