using Dtonic.Json.Base;
using System.Runtime.CompilerServices;

namespace Dtonic.Json.Extensions;
public static class ListExtensions
{
    public static void AddIfSpecified(this List<string> list, IJsonType dto, [CallerArgumentExpression(nameof(dto))] string memberName = "")
    {
        if (dto.IsSpecified)
        {
            list.Add(dto.StringifyWithKey(memberName));
        }
    }
}
