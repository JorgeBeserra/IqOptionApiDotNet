namespace IqOptionApiDotNet.Ws.Base
{
    public interface IWsIqOptionMessageCreator
    {
        string CreateIqOptionMessage(string requestId);
    }
}