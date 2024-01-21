namespace Dtonic.Json.Base;

public interface IJsonType : IDtonic
{
    bool IsSpecified { get; }

    bool IsNull { get; }
}
