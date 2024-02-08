using System.Runtime.CompilerServices;
using System.Text;

namespace Dtonic.Json.Utils;

public struct JsonFormatter(string json)
{
    private const char OPEN_OBJECT = '{';
    private const char OPEN_ARRAY = '[';
    private const char SPACE = ' ';
    private const char CLOSE_OBJECT = '}';
    private const char CLOSE_ARRAY = ']';
    private const char COMMA = ',';
    private const char COLON = ':';
    private const char QUOTE = '"';
    private const char SLASH = '\\';

    private const short TAB_SIZE = 4;

    private readonly string _json = json;

    private bool _isQuoting;
    private bool _isEscaped;

    private short _indent;

    public string Format()
    {
        var bob = new StringBuilder();

        var chars = _json.AsSpan();
        for (var i = 0; i < chars.Length; i++)
        {
            var c = chars[i];
            SetSwitches(ref c);

            if (_isQuoting)
            {
                bob.Append(c);
            }
            else if (c == OPEN_OBJECT || c == OPEN_ARRAY)
            {
                bob.Append(c);
                bob.AppendLine();
                _indent++;
                bob.Append(SPACE, _indent * TAB_SIZE);
            }
            else if (c == CLOSE_OBJECT || c == CLOSE_ARRAY)
            {
                bob.AppendLine();
                _indent--;
                bob.Append(SPACE, _indent * TAB_SIZE);
                bob.Append(c);
            }
            else if (c == COMMA)
            {
                bob.Append(c);
                bob.AppendLine();
                bob.Append(SPACE, _indent * TAB_SIZE);
            }
            else if (c == COLON)
            {
                bob.Append(c);
                bob.Append(SPACE);
            }
            else
            {
                bob.Append(c);
            }
        }

        return bob.ToString();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void SetSwitches(ref char c)
    {
        if (c == QUOTE)
        {
            if (_isEscaped)
            {
                _isEscaped = false;
            }
            else
            {
                _isQuoting = !_isQuoting;
            }
        }
        else if (c == SLASH || _isEscaped)
        {
            _isEscaped = !_isEscaped;
        }
    }
}
