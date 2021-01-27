using ESC_POS_NET_CORE.Extensions;
using ESC_POS_NET_CORE.Interfaces.Command;

namespace ESC_POS_NET_CORE.Epson_Commands
{
    public class FontWidth : IFontWidth
    {
        public byte[] Normal()
        {
            return new byte[] { 27, '!'.ToByte(), 0 };
        }

        public byte[] DoubleWidth2()
        {
            return new byte[] { 29, '!'.ToByte(), 16 };
        }

        public byte[] DoubleWidth3()
        {
            return new byte[] { 29, '!'.ToByte(), 32 };
        }
    }
}

