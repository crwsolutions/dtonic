using Dtonic.Json.Base;

namespace Dtonic.Json.Exceptions;
public sealed class DoesNotImplementIJsonSerializableException : Exception
{
    private DoesNotImplementIJsonSerializableException(string message) : base(message)
    {

    }

    public static DoesNotImplementIJsonSerializableException Create(string className, Type type)
    {
        return new DoesNotImplementIJsonSerializableException($"'{className}' with type '{type.Name}' does not implement {nameof(IDtonic)}");
    }
}
