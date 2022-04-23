using System;
using IqOptionApiDotNet.extensions;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Ws.Base
{
    public class WsAuthenticatedMessageBase<T> : IWsAuthenticatedMessage<T>, IWsIqOptionMessageCreator
    {
        [JsonProperty("name", Order = 1)] public virtual string Name { get; set; }
        [JsonProperty("msg", Order = 2)] public virtual bool Message { get; set; }
        [JsonProperty("client_session_id", Order = 3)] public virtual string ClientSessionId { get; set; }
        [JsonProperty("request_id", Order = 4)] public virtual string RequestId { get; set; }       
        
        public virtual string CreateIqOptionMessage(string requestId)
        {
            RequestId = requestId;
            return this.AsJson();
        }

        public override string ToString()
        {
            return this.AsJson();
        }

        public TType MessageAs<TType>()
        {
            return Message.ToString().JsonAs<TType>();
        }

        public object MessageAs(Type type)
        {
            return Message.ToString().JsonAs(type);
        }
    }
}