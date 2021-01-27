using ESC_POS_NET_CORE.Extensions;
using ESC_POS_NET_CORE.Interfaces.Command;

namespace ESC_POS_NET_CORE.Epson_Commands
{
    public class InitializePrint : IInitializePrint
    {
        public byte[] Initialize()
        {
            return new byte[] { 27, '@'.ToByte() };
        }
    }
}

