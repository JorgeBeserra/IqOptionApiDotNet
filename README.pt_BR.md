<img src="https://github.com/JorgeBeserra/IqOptionApiDotNet/blob/master/img/logoapi.png" width="64" align="left" />

# IqOptionApiDotNet

IqOption Api para conectar-se a www.iqoption.com (não oficial), com o .netcore.

Favor entrar em contato via Gitter (Sugestões ou Duvidas)

[![Join the chat at https://gitter.im/IqOptionApiDotNet/Developers](https://badges.gitter.im/IqOptionApiDotNet/Developers.svg)](https://gitter.im/IqOptionApiDotNet/Developers?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

# Intalação do Pacote

```javascript
PM> Install-Package IqOptionApiDotNet

```

# Como isso funciona

Essa API usando o websocket para comunicar dados em tempo real ao servidor IqOption através do canal seguro do websocket, para que os metadados em tempo real que vêm neste canal sejam manipulados pela programação reativa .net chamada "Rx.NET", causa de centenas de fluxos de tipos de dados no apenas um canal, por isso precisamos assinar selecionado em um tópico específico.

# Marco histórico

- Posição de compra
- Assine o canal
- suporte aberto Longo / Curto para contrato de CFD (Opções Digitais)

# Últimos recursos
- Obrigatoriedade de definição de um identificador para requisições
- Obter informações financeiras
- Obter perfil de usuário por ID de usuário
- Obtenha disponibilidade dos usuários por ID de usuário
- Obtenha tabela de classificação (TOP TRADERS)
- Obter detalhes do placar com o ID do usuário


# Como User

```csharp
var client = new IqOptionApiDotNetClient("contaiqoptio", "senhaiqoption");
string requestId; // Novo

//Inicia conexão
if(await client.ConnectAsync()){

  //Pega Profile do seu Usuario.
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  var profile = await client.GetProfileAsync(requestId);
  
  //Pega Profile de acordo com os ID.
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  var userId = ""; // <-- Id do Usuario aqui!
  var profile = await client.GetUserProfileClientAsync(requestId, userId);
  
  //Pega Estado de varios usuarios com uma lista de ID.
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  long[] userId = { 0, 0, 0 }; // Substituir os zeros por IDS de usuarios
  var profile = await client.GetUsersAvailabilityAsync(requestId, userId);
  
  //Pega a Relação Top Traders.
  var profile = await client.RequestLeaderboardDealsClientAsync(0, 191, 1, 10, 64, 64, 64, 64, 2);

  //Pega um detalhado do usuario pelo id.
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  long[] countryes = {0 };
  var userId = ""; // <-- Id do Usuario aqui!
  var leader = await client.RequestLeaderboardUserinfoDealsClientAsync(requestId, countryes, userId);

  // Abrir ordem EUR / USD no menor período (1min)
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  var exp = DateTime.Now.AddMinutes(1);
  var buyResult = await api.BuyAsync(requestId, ActivePair.EURUSD, 1, OrderDirection.Call, exp);

  // Obter dados de velas
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  var candles = await api.GetCandlesAsync(requestId, ActivePair.EURUSD, TimeFrame.Min1, 100, DateTimeOffset.Now);
  _logger.LogInformation($"CandleCollections received {candles.Count}");


  // Assinar o par para obter dados em tempo real para tf1min e tf5min
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  var streamMin1 = await api.SubscribeRealtimeDataAsync(ActivePair.EURUSD, TimeFrame.Min1);
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  var streamMin5 = await api.SubscribeRealtimeDataAsync(requestId, ActivePair.EURUSD, TimeFrame.Min5);

  streamMin5.Merge(streamMin1)
      .Subscribe(candleInfo => {
          _logger.LogInformation($"Agora {ActivePair.EURUSD} {candleInfo.TimeFrame} : Bid={candleInfo.Bid}\t Ask={candleInfo.Ask}\t");
  });

  // Remove assinatura do par, e não irá mais receber dados em tempo real para impressão min5 no console
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  await api.UnSubscribeRealtimeData(requestId, ActivePair.EURUSD, TimeFrame.Min5);

}

```

## Exemplos de casos de uso

Este é um exemplo de casos de uso em que esta API pode resolver seus problemas

### Seguidor de negociação

```csharp
public async Task TradingFollower_ExampleAsync() {

    var trader = new IqOptionApiDotNetClient("a@b.com", "changeme");
    var follower = new IqOptionApiDotNetClient("b@c.com", "changeme");

    await Task.WhenAll(trader.ConnectAsync(), follower.ConnectAsync());

    trader.WsClient.OpenOptionObservable().Subscribe(x => {
        requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
        follower.BuyAsync(requestId, x.Active, (int) x.Amount, x.Direction, x.ExpirationTime);
    });
}
```

## Função BuyAsync

Para abrir a opção turbo dentro da duração (1M-5M)

```csharp
var api = new IqOptionApiDotNetClient("email@email.com", "senha");

try {
    // Iniciando Seção
    if (await api.ConnectAsync()) {
        //EUR / USD de ordem aberta no menor período (1min)
        requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
        var exp = DateTime.Now.AddMinutes(1);
        await api.BuyAsync(requestId, ActivePair.EURUSD, 1, OrderDirection.Call, exp);
    }
}
catch (Exception ex) {
    Console.WriteLine(ex.Message);
}
finally {
    Console.ReadLine();
}

```

## Função TradersMood (Humor dos Traders)

Para verificar o humor dos traders em Instrumento/Ativo específico
![Alt text](img/TraderMoodChanged_Portal.png)

```csharp
var api = new IqOptionApiDotNetClient("email@email.com", "senha");

try {
    //logging in
    if (await api.ConnectAsync()) {

        // Assina o canal para receber dados das alterações de Humor
        api.WsClient.TradersMoodObservable().Subscribe(x => {

            // Impressão dos valores aqui!
            _logger.Information(
                $"Humor dos traders em {x.InstrumentType} - {x.ActivePair} valores Superior :{x.Higher}, Baixo: {x.Lower}"
            );
        });

        // Assinar o recebimento de dados em 2 Ativos
        requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
        api.SubscribeTradersMoodChanged(requestId, InstrumentType.BinaryOption, ActivePair.EURUSD);
        
        requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
        api.SubscribeTradersMoodChanged(requestId, InstrumentType.BinaryOption, ActivePair.GBPUSD);

        // Uma pequena pausa para ver apresentação dos dados durante 10 segundos
        await Task.Delay(10000);

        // E agora remove assinatura GBPUSD e agora os humores não serão mais enviados
        requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
        api.UnSubscribeTradersMoodChanged(requestId, InstrumentType.BinaryOption, ActivePair.GBPUSD);
    }
}
catch (Exception ex) {
    Console.WriteLine(ex.Message);
}
finally {
    Console.ReadLine();
}

```

![Alt text](img/TraderMoodChanged.png)

### Copiar Traders

Agora usando o modo ReactiveUI para assinar a alteração do modelo após esta

```csharp

    var trader = new IqOptionApiDotNetClient("a@b.com", "changeme");
    var follower = new IqOptionApiDotNetClient("b@c.com", "changeme");

    await Task.WhenAll(trader.ConnectAsync(), follower.ConnectAsync());

    trader.WsClient.OpenOptionObservable().Subscribe(x => {
        requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
        follower.BuyAsync(x.Active, (int) x.Amount, x.Direction, x.ExpirationTime);
    });

```

# Ajude-me

Se de alguma forma ajudei você com qualquer um dos conteúdos que foi disponibilizado, favor ajude tambem criando um pullrequest más, também agradeceria muito seu apoio me pagando um café!!! :) . <br>
<a href="https://buymeacoffee.com/jorgesouza" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/black_img.png" alt="Buy Me A Coffee" style="height: auto !important;width: auto !important;" ></a> Jorge Souza<br>
<a href="https://www.buymeacoffee.com/6VF3XHb" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/black_img.png" alt="Buy Me A Coffee" style="height: auto !important;width: auto !important;" ></a> MongkonEiadon (Repositório Base) 
