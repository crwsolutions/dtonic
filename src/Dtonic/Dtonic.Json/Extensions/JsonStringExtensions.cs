using System.Text;

namespace Dtonic.Json.Extensions;
internal static class JsonStringExtensions
{
    public static string JsonEscape(this string s)
    {
        if (s.Length == 0)
        {
            return "\"\"";
        }

        var sb = new StringBuilder(s.Length + 4);

        var chars = s.AsSpan();

        sb.Append('"');
        for (int i = 0; i < s.Length; i += 1)
        {
            var c = chars[i];
            switch (c)
            {
                case '\\':
                case '"':
                    sb.Append('\\');
                    sb.Append(c);
                    break;
                case '/':
                    sb.Append('\\');
                    sb.Append(c);
                    break;
                case '\b':
                    sb.Append("\\b");
                    break;
                case '\t':
                    sb.Append("\\t");
                    break;
                case '\n':
                    sb.Append("\\n");
                    break;
                case '\f':
                    sb.Append("\\f");
                    break;
                case '\r':
                    sb.Append("\\r");
                    break;
                default:
                    if (c < ' ')
                    {
                        var t = "000" + Convert.ToHexString(new byte[] { (byte)c });
                        sb.Append("\\u" + t.Substring(t.Length - 4));
                    }
                    else
                    {
                        sb.Append(c);
                    }
                    break;
            }
        }
        sb.Append('"');
        return sb.ToString();
    }
}
