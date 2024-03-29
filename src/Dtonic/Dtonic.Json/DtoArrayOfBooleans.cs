﻿using Dtonic.Dto.Base;
using Dtonic.Dto.Utils;
using System.Diagnostics;
using System.Text.Json;

namespace Dtonic.Dto;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public sealed record DtoArrayOfBooleans : DtoValueBase<IEnumerable<bool?>?>
{
    private DtoArrayOfBooleans() { }

    public DtoArrayOfBooleans(IEnumerable<bool?>? value) : base(value)
    {
    }

    public static DtoArrayOfBooleans Unspecified => new();

    private string GetDebuggerDisplay() => GetDebuggerDisplay(nameof(DtoArrayOfBooleans), _value);
    public override string Stringify()
    {
        if (IsNull)
        {
            return NULL;
        }

        var bob = new StringifyArrayBuilder();
        foreach (var item in Value)
        {
            bob.Add(item is null ? NULL : item.Value.ToString().ToLower());
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
        var lst = new List<bool?>();
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
                else if (jsonReader.TokenType == JsonTokenType.True)
                {
                    lst.Add(true);
                }
                else if (jsonReader.TokenType == JsonTokenType.False)
                {
                    lst.Add(false);
                }
            }
        }

        Value = lst;
    }

    //public static implicit operator DtoArrayOfBooleans(Collection<bool> items) => new((IEnumerable<bool>)items);
    public static implicit operator DtoArrayOfBooleans(bool[] items) => new(Array.ConvertAll(items, item => (bool?)item).AsEnumerable());
    //public static implicit operator DtoArrayOfBooleans(ArrayList items) => new(items);
    //public static implicit operator DtoArrayOfBooleans(List<bool> items) => new((IEnumerable<bool>?)items);
    //public static implicit operator DtoArrayOfBooleans(Queue items) => new(items);
    //public static implicit operator DtoArrayOfBooleans(ConcurrentQueue<bool> items) => new((IEnumerable<bool>?)items);
    //public static implicit operator DtoArrayOfBooleans(Stack items) => new(items);
    //public static implicit operator DtoArrayOfBooleans(ConcurrentStack<bool> items) => new((IEnumerable<bool>?)items);
    //public static implicit operator DtoArrayOfBooleans(LinkedList<bool> items) => new((IEnumerable<bool>?)items);
}