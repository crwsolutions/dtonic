using Dtonic.Dto.Base;
using System.Diagnostics;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoString : DtoValueBase<string?>
{
    private DtoString() { }

    public DtoString(string? value) : base(value)
    {
    }

    public static DtoString Unspecified => new();

    private string GetDebuggerDisplay()
    {
        return GetDebuggerDisplay(nameof(DtoString));
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

    public static implicit operator DtoString(string value) => new(value);
}
