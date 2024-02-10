namespace Dtonic.Json.Exceptions;
public sealed class JsonStartsWithUnexpectedToken : Exception
{

    public JsonStartsWithUnexpectedToken(string? message) : base(message)
    {
    }
}