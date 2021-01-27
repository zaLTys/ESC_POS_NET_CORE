using ESC_POS_NET_CORE.Extensions;
using ESC_POS_NET_CORE.Interfaces.Command;

namespace ESC_POS_NET_CORE.Epson_Commands
{
    public class PaperCut : IPaperCut
    {
        public byte[] Full()
        {
            return new byte[] { 29, 'V'.ToByte(), 65, 0 };
        }

        public byte[] Partial()
        {
            return new byte[] { 29, 'V'.ToByte(), 65, 1 };
        }
    }
}

