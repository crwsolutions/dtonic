namespace Dtonic.Json.Base;

public interface IJsonType : IDtonic
{
    bool IsSet { get; }

    bool IsNull { get; }
}
