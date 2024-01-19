using Dtonic.Json.Base;
using Dtonic.Json.Exceptions;
using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonObject<T> : JsonTypeBase<T?> where T : class, IDtonic, new()
{
    private JsonObject() { }

    public JsonObject(T? value) : base(value)
    {
    }

    public static JsonObject<T> Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(JsonObject<T>));
    public override string Stringify() 
    {
        if (IsNull)
        {
            return "null";
        }

        if (Value is IDtonic dto)
        {
            return dto.Stringify();
        }

        throw DoesNotImplementIJsonSerializableException.Create("?", Value.GetType());
    }
    public override void Parse(ref Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            Value = null;
            return;
        }
        if (jsonReader.TokenType == JsonTokenType.StartObject)
        {
            var t = new T();
            t.Parse(ref jsonReader);
            Value = t;
            return;
        }
        throw new Exception("Unknown type");
    }

    public static implicit operator JsonObject<T>(T value)
    {
        return new(value);
    }
}