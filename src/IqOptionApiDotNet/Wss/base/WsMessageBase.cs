using System;
using IqOptionApiDotNet.extensions;
using Newtonsoft.Json;

namespace IqOptionApiDotNet.Ws.Base
{
    public class WsMessageBase<T> : IWsMessage<T>, IWsIqOptionMessageCreator
    {
        [JsonProperty("name", Order = 1)] public virtual string Name { get; set; }
        [JsonProperty("request_id", Order = 2)] public virtual string RequestId { get; set; }
        [JsonProperty("local_time", Order = 3)] public virtual int LocalTime { get; set; }
        [JsonProperty("msg", Order = 4)] public virtual T Message { get; set; }
        //[JsonProperty("status", Order = Int32.MaxValue)] public virtual int StatusCode { get; set; }
        //[JsonProperty("microserviceName", Order = 10)] public string MicroserviceName { get; set; }
        //[JsonProperty("version", Order = 11)] public virtual string Version { get; set; } = "1.0";
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