using System.Runtime.CompilerServices;
using IqOptionApiDotNet.Ws.Base;

[assembly: InternalsVisibleTo("IqOptionApiDotNet.Unit", AllInternalsVisible = true)]

namespace IqOptionApiDotNet.Ws.Request
{
    internal class GetInitializationDataModel
    {
    }

    internal sealed class GetInitializationDataRequestMessage : WsSendMessageBase<GetInitializationDataModel>
    {
        public GetInitializationDataRequestMessage()
        {
            Message = new RequestBody<GetInitializationDataModel>
            {
                RequestBodyType = RequestMessageBodyType.GetInitializationData,
                Body = new GetInitializationDataModel
                {
                }
            };
            Version = "3.0";
        }
    }
}