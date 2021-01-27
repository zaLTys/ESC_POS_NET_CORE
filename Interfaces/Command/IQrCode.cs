using ESC_POS_NET_CORE.Enums;

namespace ESC_POS_NET_CORE.Interfaces.Command
{
    internal interface IQrCode
    {
        byte[] Print(string qrData);
        byte[] Print(string qrData, QrCodeSize qrCodeSize);
    }
}

