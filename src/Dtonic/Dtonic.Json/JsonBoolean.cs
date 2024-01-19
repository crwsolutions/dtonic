using Dtonic.Json.Base;
using System.Diagnostics;
using System.Text.Json;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonBoolean : JsonTypeBase<bool?>
{
    private JsonBoolean() { }

    public JsonBoolean(bool? value) : base(value)
    {
    }

    public static JsonBoolean Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(JsonBoolean));

    public override string Stringify() => IsNull ? "null" : Value.ToString()!.ToLowerInvariant();

    public override void Parse(ref Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            Value = null;
            return;
        }
        if (jsonReader.TokenType == JsonTokenType.True)
        {
            Value = true;
            return;
        }
        if (jsonReader.TokenType == JsonTokenType.False)
        {
            Value = false;
            return;
        }
        throw new Exception("Unknown type");
    }

    public static implicit operator JsonBoolean(bool value)
    {
        return new(value);
    }
}