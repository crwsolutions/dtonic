namespace Dtonic.Json.Extensions;
public static class JsonArrayExtensions
{
    public static JsonArray<T> ToJsonArray<T>(this IEnumerable<T> items) => new(items);
    public static JsonArray<T> ToJsonArray<T>(this List<T> items) => new(items);
}
