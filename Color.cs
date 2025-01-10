using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordWebhook
{
    public class Color
    {
        public static int FromHex(string hex)
        {
            if (hex.StartsWith("#"))
                hex = hex.Substring(1);

            return Convert.ToInt32(hex, 16);
        }
    }
}
