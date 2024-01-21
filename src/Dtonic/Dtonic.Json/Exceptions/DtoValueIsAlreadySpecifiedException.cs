namespace Dtonic.Dto.Exceptions;

/// <summary>
/// You ran into this exception because you cannot set a value twice. Maybe it is a problem in the dto.
/// </summary>
public sealed class DtoValueIsAlreadySpecifiedException : Exception
{ }