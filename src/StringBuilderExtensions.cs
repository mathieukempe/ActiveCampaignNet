using System;
using System.Text;

namespace ActiveCampaignNet
{
    public static class StringBuilderExtensions
    {
        public static void AppendUrlEncoded(this StringBuilder sb, string name, string value)
        {
            if (sb.Length != 0)
                sb.Append("&");
            sb.Append(Uri.EscapeUriString(name));
            sb.Append("=");
            sb.Append(Uri.EscapeUriString(value));
        }
    }
}