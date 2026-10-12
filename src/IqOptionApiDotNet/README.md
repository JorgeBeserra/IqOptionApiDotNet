# IqOptionApiDotNet

An unofficial .NET client for the IQ Option platform, using HTTP for login and
WebSocket streams for real-time data and account events.

## Installation

Requires **.NET 9.0** or a compatible newer target framework.

```sh
dotnet add package IqOptionApiDotNet
```

## Quick start

Provide your credentials through environment variables, then connect and read
your profile. This example does not place trades.

```csharp
using System;
using IqOptionApiDotNet;

var email = Environment.GetEnvironmentVariable("IQOPTION_EMAIL")
    ?? throw new InvalidOperationException("Set IQOPTION_EMAIL.");
var password = Environment.GetEnvironmentVariable("IQOPTION_PASSWORD")
    ?? throw new InvalidOperationException("Set IQOPTION_PASSWORD.");

using var client = new IqOptionApiDotNetClient(email, password);

if (!await client.ConnectAsync())
{
    Console.WriteLine("Login failed.");
    return;
}

var profile = await client.GetProfileAsync(Guid.NewGuid().ToString("N"));
Console.WriteLine($"User: {profile.profileResult.UserId}");
```

Use a unique request ID for each request. Keep observable subscriptions alive
while receiving events, and dispose them when they are no longer needed.

## Features

- Account profile and practice/real balance queries.
- Historical candles and real-time candle streams.
- Binary, turbo and digital option requests.
- Option results and portfolio position events.
- Alerts, market information and leaderboard queries.

Availability depends on the account, the instrument and the platform's current
protocol. This library is not affiliated with IQ Option.

## Documentation and examples

- [Project documentation](https://github.com/JorgeBeserra/IqOptionApiDotNet/blob/master/README.md)
- [Documentação em português](https://github.com/JorgeBeserra/IqOptionApiDotNet/blob/master/README.pt_BR.md)
- [Sample applications](https://github.com/JorgeBeserra/IqOptionApiDotNet/tree/master/Sample/IqOptionApiDotNet.Samples)
- [Receiving option results](https://github.com/JorgeBeserra/IqOptionApiDotNet/blob/master/docs/option-results.md)
- [Release downloads](https://github.com/JorgeBeserra/IqOptionApiDotNet/releases)
- [Report an issue](https://github.com/JorgeBeserra/IqOptionApiDotNet/issues)

## License

[MIT](https://github.com/JorgeBeserra/IqOptionApiDotNet/blob/master/LICENSE).
