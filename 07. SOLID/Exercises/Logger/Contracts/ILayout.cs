namespace Logger.Contracts
{
    public interface ILayout
    {
        string FormatMessage(IMessage message);
    }
}
