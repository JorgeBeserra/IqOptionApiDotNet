using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using IqOptionApiDotNet.Models;
using IqOptionApiDotNet.Models.BinaryOptions;
using IqOptionApiDotNet.utilities;
using IqOptionApiDotNet.Ws.Base;

// ReSharper disable once CheckNamespace
namespace IqOptionApiDotNet.Ws
{
    public partial class IqOptionWebSocketClient
    {
        private readonly Subject<UserSettings> _usersettingsSubject = new Subject<UserSettings>();

        public IObservable<UserSettings> UserSettingsObservable => _usersettingsSubject.AsObservable();

        [SubscribeForTopicName(MessageType.UserSettings, typeof(UserSettings))]
        public void Subscribe(UserSettings value)
        {
            _usersettingsSubject.OnNext(value);
        }

        [Predisposable]
        internal void OnUserSettingsDisposal()
        {
            _usersettingsSubject.OnCompleted();
        }
    }
}