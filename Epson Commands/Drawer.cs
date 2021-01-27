using ESC_POS_NET_CORE.Interfaces.Command;

namespace ESC_POS_NET_CORE.Epson_Commands
{
    public class Drawer : IDrawer
    {
        public byte[] Open()
        {
            return new byte[] { 27, 112, 0, 60, 120 };
        }
    }
}

