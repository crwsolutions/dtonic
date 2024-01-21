using Dtonic.Json.Base;
using Dtonic.Json.Extensions;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;

namespace Dtonic.Json.Utils;
public sealed class StringifyObjectBuilder : IEnumerable
{
    private readonly StringBuilder _bob = new();
    private bool _isFirst = true;

    public void Add(IJsonType dto, [CallerArgumentExpression(nameof(dto))] string memberName = "")
    {
        if (dto.IsSet)
        {
            if (_isFirst)
            {
                _isFirst = false;
            }
            else
            {
                _bob.Append(',');
            }
            _bob.Append(dto.StringifyWithKey(memberName));
        }
    }

    public IEnumerator GetEnumerator() => throw new NotImplementedException();

    public override string ToString()
    {
        return $"{{{_bob}}}";
    }
}
