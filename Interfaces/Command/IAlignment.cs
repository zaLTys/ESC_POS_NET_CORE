namespace ESC_POS_NET_CORE.Interfaces.Command
{
    internal interface IAlignment
    {
        byte[] Left();
        byte[] Right();
        byte[] Center();
    }
}

