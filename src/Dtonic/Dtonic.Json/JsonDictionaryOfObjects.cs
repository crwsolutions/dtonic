using Dtonic.Json.Base;
using Dtonic.Json.Exceptions;
using Dtonic.Json.Utils;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonDictionaryOfObjects<T> : JsonTypeBase<IDictionary<string, T?>> where T : class, IDtonic, new()
{
    private JsonDictionaryOfObjects() { }

    public JsonDictionaryOfObjects(IDictionary<string, T?>? value) : base(value)
    {
    }

    public static JsonDictionaryOfObjects<T> Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(JsonDictionaryOfObjects<T>));

    public override string Stringify()
    {
        if (IsNull)
        {
            return "null";
        }
        var bob = new StringifyDictionaryBuilder();
        foreach (var item in Value)
        {
            bob.Add(item.Key, GetStringOfType(item.Value));
        }
        return bob.ToString();
    }

    private static string GetStringOfType(object? value)
    {
        if (value == null)
        {
            return "null";
        }
        if (value is string)
        {
            return $"\"{value}\"";
        }
        if (value is float f)
        {
            return f.ToString(CultureInfo.InvariantCulture);
        }
        if (value is double d)
        {
            return d.ToString(CultureInfo.InvariantCulture);
        }
        if (value is decimal m)
        {
            return m.ToString(CultureInfo.InvariantCulture);
        }
        if (IsSimple(value.GetType()))
        {
            return value.ToString()!;
        }
        if (value is IDtonic serializable)
        {
            return serializable.Stringify();
        }

        throw DoesNotImplementIJsonSerializableException.Create("?", value.GetType());
    }

    private static bool IsSimple(Type type)
    {
        return type.IsPrimitive
          || type.IsEnum;
    }
    public override void Parse(ref Utf8JsonReader jsonReader) => throw new NotImplementedException();

    public static implicit operator JsonDictionaryOfObjects<T>(Dictionary<string, T>? items) => new((IDictionary<string, T?>?)items);
}
