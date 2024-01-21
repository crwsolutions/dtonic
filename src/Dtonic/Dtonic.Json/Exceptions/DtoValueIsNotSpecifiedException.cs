namespace Dtonic.Dto.Exceptions;

/// <summary>
/// You cannot check or touch the value when it is not specified. First check the IsSpecified property.
/// </summary>
public sealed class DtoValueIsNotSpecifiedException : Exception
{ }
