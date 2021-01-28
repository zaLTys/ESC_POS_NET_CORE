using ESC_POS_NET_CORE.Enums;

namespace ESC_POS_NET_CORE.Interfaces.Command
{
    interface IBarCode
    {
        byte[] Code128(string code,Positions printString);
        byte[] Code39(string code, Positions printString);
        byte[] Code39Expanded(string code, Positions printString);
        byte[] Ean13(string code, Positions printString);
    }
}

