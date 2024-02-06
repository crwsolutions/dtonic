using Dtonic.Dto.Base;
using Dtonic.Dto.Exceptions;
using System.Diagnostics;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoObject<T> : DtoValueBase<T?> where T : class, IDtonic, new()
{
    private DtoObject() { }

    public DtoObject(T? value) : base(value)
    {
    }

    public static DtoObject<T> Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoObject<T>));
    public override string Stringify()
    {
        if (IsNull)
        {
            return NULL;
        }

        if (Value is IDtonic dto)
        {
            return dto.Stringify();
        }

        throw DtoDoesNotImplementIDtoSerializableException.Create("?", Value.GetType());
    }
    public override void Parse(ref Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            Value = default;
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

    public static implicit operator DtoObject<T>(T? value) => new(value);
}