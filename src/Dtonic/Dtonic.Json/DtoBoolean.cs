using Dtonic.Dto.Base;
using System.Diagnostics;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoBoolean : DtoValueBase<bool?>
{
    private DtoBoolean() { }

    public DtoBoolean(bool? value) : base(value)
    {
    }

    public static DtoBoolean Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoBoolean));

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

    public static implicit operator DtoBoolean(bool value)
    {
        return new(value);
    }
}