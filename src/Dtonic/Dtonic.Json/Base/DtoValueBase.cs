using Dtonic.Dto.Exceptions;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Dtonic.Dto.Base;

[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public abstract record DtoValueBase<T> : IDtoValue
{
    protected T? _value;

    protected DtoValueBase()
    {
        _value = default;
    }

    public DtoValueBase(T? value)
    {
        _value = value;
        IsSpecified = true;
    }

    public T? Value
    {
        get
        {
            return IsSpecified ? _value : throw new DtoValueIsNotSpecifiedException();
        }
        protected set
        {
            if (IsSpecified)
            {
                throw new DtoValueIsAlreadySpecifiedException();
            }
            _value = value;
            IsSpecified = true;
        }
    }

    /// <summary>
    /// Indication whether the <see cref="Value">Value</see> is specified. Not an indication whether the value is null. See <see cref="IsNull">IsNull</see> for that.
    /// </summary>
    /// <remarks>
    /// A value is considered specified if it is assigned. The following examples show such an assigment, dto:
    /// <code>
    ///  {"prop": null} //or
    ///  {"prop": "somevalue"}
    /// </code>
    /// Or from code:
    /// <code>
    ///  x.prop = null;
    ///  x.prop = "somevalue";
    /// </code>
    /// So only when you leave it alone, do not touch or reference it. It is considered unspecified.
    /// </remarks>
    public bool IsSpecified { set; get; } = false;

    /// <summary>
    /// Indication whether the <see cref="Value">Value</see> is null.
    /// </summary>
    [MemberNotNullWhen(false, nameof(Value))]
    public bool IsNull => _value == null;

    private string GetDebuggerDisplay()
    {
        return GetDebuggerDisplay(nameof(DtoValueBase<T>));
    }

    protected string GetDebuggerDisplay(string className)
    {
        return IsSpecified ? $"{className}: '{_value}'" : $"{className}: - not set -";
    }

    public abstract string Stringify();

    public abstract void Parse(ref Utf8JsonReader jsonReader);
}