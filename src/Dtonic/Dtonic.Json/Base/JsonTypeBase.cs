using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Dtonic.Json.Base;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public abstract class JsonTypeBase<T> : IJsonType
{
    protected readonly T? _value;

    protected JsonTypeBase()
    {
        _value = default;
    }

    public JsonTypeBase(T value)
    {
        _value = value;
        IsSet = true;
    }

    public T? Value => _value;

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
}