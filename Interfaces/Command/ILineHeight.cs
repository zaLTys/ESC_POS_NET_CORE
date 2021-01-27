namespace ESC_POS_NET_CORE.Interfaces.Command
{
    interface ILineHeight
    {
        byte[] Normal();
        byte[] SetLineHeight(byte height);
    }
}
