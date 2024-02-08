using System.Text;

namespace Dtonic.Json.Extensions;
internal static class JsonStringExtensions
{
    public static string JsonEscape(this string s)
    {
        var chars = s.AsSpan();

        var sb = new StringBuilder(chars.Length + 4);
        sb.Append('"');
        for (int i = 0; i < chars.Length; i++)
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
                        sb.Append($"\\u{Convert.ToHexString(new byte[] { (byte)c }).PadLeft(4, '0')}");
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
