using Dtonic.Dto.Base;

namespace Dtonic.Dto.Exceptions;
public sealed class DtoDoesNotImplementIDtoSerializableException : Exception
{
    private DtoDoesNotImplementIDtoSerializableException(string message) : base(message)
    {

    }

    public static DtoDoesNotImplementIDtoSerializableException Create(string className, Type type)
    {
        return new DtoDoesNotImplementIDtoSerializableException($"'{className}' with type '{type.Name}' does not implement {nameof(IDtonic)}");
    }
}
