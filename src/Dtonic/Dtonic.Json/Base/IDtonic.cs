namespace Dtonic.Dto.Base;

public interface IDtonic
{
    /// <summary>
    /// Convert object to json string
    /// </summary>
    string Stringify();

    /// <summary>
    /// Populate object from current position in jsonReader
    /// </summary>
    void Parse(ref System.Text.Json.Utf8JsonReader jsonReader);
}