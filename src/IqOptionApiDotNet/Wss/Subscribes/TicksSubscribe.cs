using System;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Request;

// ReSharper disable once CheckNamespace
namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        private long _heartbeatTick;
        private long _serverTimeTick;
        public DateTimeOffset Heartbeat => DateTimeOffset.FromUnixTimeMilliseconds(_heartbeatTick);
        public DateTimeOffset ServerTime => DateTimeOffset.FromUnixTimeMilliseconds(_serverTimeTick);

        private void SetHeartbeatTick(long heartbeat)
        {
            _heartbeatTick = heartbeat;

            // sync back the heartbeat to server
            var requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
            SendMessageAsync(requestId, new HeartbeatAcknowledgeRequest(Heartbeat)).ConfigureAwait(true);
        }

        private void SetServerTime(long serverTime)
        {
            _serverTimeTick = serverTime;
        }
    }
}