using Dtonic.Dto.Base;
using Dtonic.Dto.Utils;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoDictionaryWithBooleans : DtoValueBase<IDictionary<string, bool?>>
{
    private DtoDictionaryWithBooleans() { }

    public DtoDictionaryWithBooleans(IDictionary<string, bool?>? value) : base(value)
    {
    }

    public static DtoDictionaryWithBooleans Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoDictionaryWithBooleans));

    public override string Stringify()
    {
        if (IsNull)
        {
            return "null";
        }
        var bob = new StringifyDictionaryBuilder();
        foreach (var item in Value)
        {
            bob.Add(item.Key, item.Value == null ? "null" : item.Value.Value.ToString(CultureInfo.InvariantCulture).ToLower());
        }
        return bob.ToString();
    }

    public override void Parse(ref Utf8JsonReader jsonReader) => throw new NotImplementedException();

    public static implicit operator DtoDictionaryWithBooleans(Dictionary<string, bool?>? items) => new((IDictionary<string, bool?>?)items);
}
