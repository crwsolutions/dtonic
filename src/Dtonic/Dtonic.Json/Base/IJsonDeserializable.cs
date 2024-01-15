namespace Dtonic.Json.Base;

public interface IJsonDeserializable
{
    void Parse(System.Text.Json.Utf8JsonReader jsonReader);
}