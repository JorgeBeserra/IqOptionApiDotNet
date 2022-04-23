using System;
using System.Linq;
using System.Runtime.CompilerServices;
using IqOptionApiDotNet.Converters.JsonConverters;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[assembly: InternalsVisibleTo("IqOptionApiDotNet.Unit", AllInternalsVisible = true)]

namespace IqOptionApiDotNet.Ws.Request
{
    internal class GetCoreProfileClientModel
    {
    }
    
    internal sealed class GetCoreProfileClientRequestMessage : WsSendMessageBase<GetCoreProfileClientModel>
    {
        public GetCoreProfileClientRequestMessage()
        {
            Message = new RequestBody<GetCoreProfileClientModel>
            {
                RequestBodyType = RequestMessageBodyType.CoreGetProfile,
                Body = new GetCoreProfileClientModel
                {
                }
            };
        }
    }
}