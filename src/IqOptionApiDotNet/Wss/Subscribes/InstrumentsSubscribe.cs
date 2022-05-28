using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Ws.Request;

// ReSharper disable once CheckNamespace
namespace IqOptionApiDotNet.Ws
{
    
    public partial class IqOptionWebSocketClient
    {
        #region [Instruments]

        private InstrumentResultSet _instrumentResultSet = new InstrumentResultSet();

        private readonly Subject<InstrumentResultSet> _instrumentResultSetSubject = new Subject<InstrumentResultSet>();

        public IObservable<InstrumentResultSet> InstrumentResultSetObservable =>
            _instrumentResultSetSubject.Publish().RefCount();


        public Task<InstrumentResultSet> SendInstrumentsRequestAsync(string requestId, params InstrumentType[] instrumentTypes)
        {
            var tcs = new TaskCompletionSource<InstrumentResultSet>();
            try
            {
                //subscribe for the lastest result
                var obs = InstrumentResultSetObservable
                    .Subscribe(x => { tcs.TrySetResult(x); });

                //clear before query new 
                _instrumentResultSet = new InstrumentResultSet();
                
                Task.WhenAll(
                    SendMessageAsync(requestId, new GetInstrumentWsRequest(InstrumentType.CFD)),
                    SendMessageAsync(requestId, new GetInstrumentWsRequest(InstrumentType.Forex)),
                    SendMessageAsync(requestId, new GetInstrumentWsRequest(InstrumentType.Crypto))
                );
            }

            catch (Exception ex)
            {
                tcs.TrySetException(ex);
            }

            return tcs.Task;
        }

        #endregion
    }
}