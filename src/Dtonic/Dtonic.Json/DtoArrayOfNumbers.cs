using Dtonic.Dto.Base;
using Dtonic.Dto.Utils;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoArrayOfNumbers : DtoValueBase<IEnumerable<decimal?>?>
{
    public DtoArrayOfNumbers() { }

    public DtoArrayOfNumbers(IEnumerable<decimal?>? value) : base(value)
    {
    }

    public static DtoArrayOfNumbers Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoArrayOfNumbers), _value);

    public override string Stringify()
    {
        if (IsNull)
        {
            return NULL;
        }

        var bob = new StringifyArrayBuilder();
        foreach (var item in Value)
        {
            bob.Add(item is null ? NULL : item.Value.ToString(CultureInfo.InvariantCulture));
        }

        return bob.ToString();
    }
    public override void Parse(ref Utf8JsonReader jsonReader)
    {
        jsonReader.Read();
        if (jsonReader.TokenType == JsonTokenType.Null)
        {
            Value = null;
            return;
        }

        var lst = new List<decimal?>();
        if (jsonReader.TokenType == JsonTokenType.StartArray)
        {
            while (jsonReader.Read())
            {
                if (jsonReader.TokenType == JsonTokenType.EndArray)
                {
                    break;
                }

                if (jsonReader.TokenType == JsonTokenType.Null)
                {
                    lst.Add(null);
                }
                else if (jsonReader.TokenType == JsonTokenType.Number)
                {
                    lst.Add(jsonReader.GetDecimal());
                }
            }
        }

        Value = lst;
    }

    //public static implicit operator DtoArrayOfNumbers(Collection<decimal> items) => new((IEnumerable<decimal>)items);
    public static implicit operator DtoArrayOfNumbers(decimal?[] items) => new(items.AsEnumerable());
    public static implicit operator DtoArrayOfNumbers(decimal[] items) => new(Array.ConvertAll(items, number => (decimal?)number).AsEnumerable());
    //public static implicit operator DtoArrayOfNumbers(ArrayList items) => new(items);
    //public static implicit operator DtoArrayOfNumbers(List<decimal> items) => new((IEnumerable<decimal>?)items);
    //public static implicit operator DtoArrayOfNumbers(Queue items) => new(items);
    //public static implicit operator DtoArrayOfNumbers(ConcurrentQueue<decimal> items) => new((IEnumerable<decimal>?)items);
    //public static implicit operator DtoArrayOfNumbers(Stack items) => new(items);
    //public static implicit operator DtoArrayOfNumbers(ConcurrentStack<decimal> items) => new((IEnumerable<decimal>?)items);
    //public static implicit operator DtoArrayOfNumbers(LinkedList<decimal> items) => new((IEnumerable<decimal>?)items);
}