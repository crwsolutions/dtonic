using System.Collections;
using System.Text;

namespace Dtonic.Dto.Utils;
public sealed class StringifyArrayBuilder : IEnumerable
{
    private readonly StringBuilder _bob = new();
    private bool _isFirst = true;

    public void Add(string value)
    {
        if (_isFirst)
        {
            _isFirst = false;
        }
        else
        {
            _bob.Append(',');
        }
        _bob.Append(value);
    }

    public IEnumerator GetEnumerator() => throw new NotImplementedException();

    public override string ToString()
    {
        return $"[{_bob}]";
    }
}
