using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Dtonic.Json.Base;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public abstract record JsonTypeBase<T> : IJsonType
{
    protected T? _value;

    protected JsonTypeBase()
    {
        _value = default;
    }

    public JsonTypeBase(T? value)
    {
        _value = value;
        IsSet = true;
    }

    public T? Value
    {
        get
        {
            return _value;
        }
        protected set
        {
            _value = value;
            IsSet = true;
        }
    }

    public bool IsSet { set; get; } = false;

    [MemberNotNullWhen(false, nameof(Value))]
    public bool IsNull => _value == null;

    private string GetDebuggerDisplay()
    {
        return GetDebuggerDisplay(nameof(JsonTypeBase<T>));
    }

    protected string GetDebuggerDisplay(string className)
    {
        return IsSet ? $"{className}: '{_value}'" : $"{className}: - not set -";
    }

    public abstract string Stringify();
    public abstract void Parse(ref Utf8JsonReader jsonReader);
}