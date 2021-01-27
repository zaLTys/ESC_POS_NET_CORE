using System.Drawing;

namespace ESC_POS_NET_CORE.Interfaces.Command
{
    internal interface IImage
    {
        byte[] Print(Bitmap image);
    }
}
