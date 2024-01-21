namespace Dtonic.Json.Exceptions;

/// <summary>
/// You ran into this exception because you cannot set a value twice. Maybe it is a problem in the json.
/// </summary>
public sealed class ValueIsAlreadySpecifiedException : Exception
{ }