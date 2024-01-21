using Dtonic.Dto.Base;
using System.Runtime.CompilerServices;

namespace Dtonic.Dto.Extensions;

public static class DtoStringifyExtensions
{
    public static string StringifyWithKey(this IDtoValue dtoType, [CallerArgumentExpression(nameof(dtoType))] string memberName = "")
    {
        if (dtoType.IsSpecified == false)
        {
            return string.Empty;
        }

        return $"\"{memberName}\":{dtoType.Stringify()}";
    }
}
