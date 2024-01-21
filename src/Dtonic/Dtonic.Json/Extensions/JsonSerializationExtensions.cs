using Dtonic.Json.Base;
using System.Runtime.CompilerServices;

namespace Dtonic.Json.Extensions;
public static class JsonSerializationExtensions
{
    public static string StringifyWithKey(this IJsonType jsonType, [CallerArgumentExpression(nameof(jsonType))] string memberName = "")
    {
        if (jsonType.IsSpecified == false)
        {
            return string.Empty;
        }

        return $"\"{memberName}\":{jsonType.Stringify()}";
    }
}
