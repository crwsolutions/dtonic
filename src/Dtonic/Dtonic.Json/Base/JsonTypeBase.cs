using System.Diagnostics;

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

    public bool IsNull => _value == null;

    object? IJsonType.ValueAsObject => _value;

    private string GetDebuggerDisplay()
    {
        return GetDebuggerDisplay(nameof(JsonTypeBase<T>));
    }

    protected string GetDebuggerDisplay(string className)
    {
        return IsSet ? $"{className}: '{_value}'" : $"{className}: - not set -";
    }
}