using Dtonic.Dto.Base;
using Dtonic.Dto.Exceptions;
using Dtonic.Dto.Utils;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoDictionaryWithNumbers : DtoValueBase<IDictionary<string, decimal?>>
{
    private DtoDictionaryWithNumbers() { }

    public DtoDictionaryWithNumbers(IDictionary<string, decimal?>? value) : base(value)
    {
    }

    public static DtoDictionaryWithNumbers Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoDictionaryWithNumbers));

    public override string Stringify()
    {
        if (IsNull)
        {
            return "null";
        }
        var bob = new StringifyDictionaryBuilder();
        foreach (var item in Value)
        {
            bob.Add(item.Key, item.Value == null ? "null" : item.Value.Value.ToString(CultureInfo.InvariantCulture));
        }
        return bob.ToString();
    }

    public override void Parse(ref Utf8JsonReader jsonReader) => throw new NotImplementedException();

    public static implicit operator DtoDictionaryWithNumbers(Dictionary<string, decimal?>? items) => new((IDictionary<string, decimal?>?)items);
}
