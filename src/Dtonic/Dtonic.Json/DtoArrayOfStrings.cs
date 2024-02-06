using Dtonic.Dto.Base;
using Dtonic.Dto.Utils;
using System.Diagnostics;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoArrayOfStrings : DtoValueBase<IEnumerable<string?>?>
{
    private DtoArrayOfStrings() { }

    public DtoArrayOfStrings(IEnumerable<string?>? value) : base(value)
    {
    }

    public static DtoArrayOfStrings Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoArrayOfStrings));
    public override string Stringify()
    {
        if (IsNull)
        {
            return NULL;
        }

        var bob = new StringifyArrayBuilder();
        foreach (var item in Value)
        {
            bob.Add(item is null ? NULL : $"\"{item}\"");
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
        var lst = new List<string?>();
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
                else if (jsonReader.TokenType == JsonTokenType.String)
                {
                    lst.Add(jsonReader.GetString());
                }
            }
        }

        Value = lst;
    }

    //public static implicit operator DtoArrayOfStrings(Collection<string> items) => new((IEnumerable<string>)items);
    public static implicit operator DtoArrayOfStrings(Array items) => new((IEnumerable<string>?)items);
    //public static implicit operator DtoArrayOfStrings(ArrayList items) => new(items);
    //public static implicit operator DtoArrayOfStrings(List<string> items) => new((IEnumerable<string>?)items);
    //public static implicit operator DtoArrayOfStrings(Queue items) => new(items);
    //public static implicit operator DtoArrayOfStrings(ConcurrentQueue<string> items) => new((IEnumerable<string>?)items);
    //public static implicit operator DtoArrayOfStrings(Stack items) => new(items);
    //public static implicit operator DtoArrayOfStrings(ConcurrentStack<string> items) => new((IEnumerable<string>?)items);
    //public static implicit operator DtoArrayOfStrings(LinkedList<string> items) => new((IEnumerable<string>?)items);
}