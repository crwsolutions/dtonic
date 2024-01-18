namespace Dtonic.Json.Base;

public interface IDtonic
{
    string Stringify();

    void Parse(ref System.Text.Json.Utf8JsonReader jsonReader);
}