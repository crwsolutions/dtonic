using System.Collections;
using System.Text;

namespace Dtonic.Json.Utils;
public sealed class StringifyDictionaryBuilder : IEnumerable
{
    private readonly StringBuilder _bob = new();
    private bool _isFirst = true;

    public void Add(string key, string value)
    {
        if (_isFirst)
        {
            _isFirst = false;
        }
        else
        {
            _bob.Append(',');
        }
        _bob.Append("{\"");
        _bob.Append(key);
        _bob.Append("\":");
        _bob.Append(value);
        _bob.Append('}');
    }

    public IEnumerator GetEnumerator() => throw new NotImplementedException();

    public override string ToString()
    {
        return $"[{_bob}]";
    }
}
