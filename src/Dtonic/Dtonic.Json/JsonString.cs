using Dtonic.Json.Base;
using System.Diagnostics;
using System.Text.Json;

namespace Dtonic.Json;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record JsonString : JsonTypeBase<string?>
{
    private JsonString() { }

    public JsonString(string? value) : base(value)
    {
    }

    public static JsonString Unspecified => new();

    private string GetDebuggerDisplay()
    {
        return GetDebuggerDisplay(nameof(JsonString));
    }

    public override string Stringify() => IsNull ? "null" : $"\"{Value}\"";
    public override void Parse(ref Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            Value = null;
            return;
        }

        if (jsonReader.TokenType == JsonTokenType.String)
        {
            Value = jsonReader.GetString();
            return;
        }
        throw new Exception("Unknown type");
    }

    public static implicit operator JsonString(string value) => new(value);
}
