namespace ESC_POS_NET_CORE.Interfaces.Command
{
    internal interface IPaperCut
    {
        byte[] Full();
        byte[] Partial();
    }
}

