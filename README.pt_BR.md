<img src="https://github.com/JorgeBeserra/IqOptionApiDotNet/blob/master/img/logoapi.png" width="64" align="left" />

# IqOptionApiDotNet

<p align="center">
<a href="https://github.com/JorgeBeserra/IqOptionApiDotNet/actions"><img src="https://github.com/JorgeBeserra/IqOptionApiDotNet/workflows/.NET%20Core/badge.svg" alt="Action Build"></a>
<a href="https://www.nuget.org/packages/IqOptionApiDotNet/"><img src="https://buildstats.info/nuget/iqoptionapidotnet?includePreReleases=true" alt="Nuget Downloads"></a>
<a href="https://gitter.im/IqOptionApiDotNet/Developers"><img src="https://badges.gitter.im/IqOptionApiDotNet/Developers.svg" alt="Nuget Downloads"></a>
</p>

IqOption Api .Net Core para conectar-se a www.iqoption.com (não oficial).

# Intalação do Pacote
Favor não deixem de instalar usando o Gerenciador de Pacotes NUGET 

```javascript
PM> Install-Package IqOptionApiDotNet

```

# Como isso funciona

Essa API esta usando o WebSocket para se comunicar em tempo real ao servidor da IqOption através de canal seguro (WebSocket Secure), para que os metadados em tempo real que vêm neste canal sejam manipulados pela programação reativa .net chamada "Rx.NET", que acaba causando um fluxo de  centenas de tipos de dados por apenas um canal, então se faz a necessidade de escolher e assinar os tópicos desejados para isso olhe a seção Assinar (**Subscribes**), e sem seguida capture os dados através dos Observadores (**Observables**)

# Marco histórico

- Posição de compra
- Assine o canal
- suporte aberto Longo / Curto para contrato de CFD (Opções Digitais)

# Últimos recursos
- Resetar o saldo da conta de Treinamento
- Alertas (Listar, Criar, Deletar, Alterar, Observar Alterações e Observar alerta Atingido)

# Recursos
- Obrigatoriedade de definição de um identificador para requisições
- Resetar o Saldo da conta de Treinamento
- Obter informações financeiras
- Obter perfil de usuário por ID de usuário
- Obtenha disponibilidade dos usuários por ID de usuário
- Obtenha tabela de classificação (TOP TRADERS)
- Obter detalhes do placar com o ID do usuário
- Resetar o saldo da conta de Treinamento
- Alertas (Listar, Criar, Deletar, Alterar, Observar Alterações e Observar alerta Atingido)

# Como Usar

```csharp
var client = new IqOptionApiDotNetClient("emailIqOption", "senhaIqOption");
string requestId; // Novo

//Inicia conexão
if(await client.ConnectAsync()){

  //Pega Profile do seu Usuario.
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  var profile = await client.GetProfileAsync(requestId);
  
  //Pega Profile de acordo com os ID.
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  var userId = ""; // <-- Id do Usuario aqui!
  var profileUser = await client.GetUserProfileClientAsync(requestId, userId);
  
  //Pega Estado de varios usuarios com uma lista de ID.
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  long[] userId = { 0, 0, 0 }; // Substituir os zeros por IDS de usuarios
  var userAvailability = await client.GetUsersAvailabilityAsync(requestId, userId);
  
  //Pega a Relação Top Traders.
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // New
  CountryType country = CountryType.Worldwide;
  long from_position = 1;
  long to_position = 10;
  var leader = await client.RequestLeaderboardDealsClientAsync(requestId, country, from_position, to_position);

  // Pega um detalhado do usuario pelo id.
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // New
  CountryType[] countryes = {CountryType.Worldwide, };
  var userId = ""; // <-- User ID here!
  var leader = await client.RequestLeaderboardUserinfoDealsClientAsync(requestId, countryes, userId);

  // Abrir ordem EUR / USD no menor período (1min)
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  var exp = DateTime.Now.AddMinutes(1);
  var buyResult = await client.BuyAsync(requestId, ActivePair.EURUSD, 1, OrderDirection.Call, exp);

  // Obter dados de velas
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  var candles = await client.GetCandlesAsync(requestId, ActivePair.EURUSD, TimeFrame.Min1, 100, DateTimeOffset.Now);
  _logger.LogInformation($"CandleCollections received {candles.Count}");


  // Assinar o par para obter dados em tempo real para tf1min e tf5min
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  var streamMin1 = await client.SubscribeRealtimeDataAsync(ActivePair.EURUSD, TimeFrame.Min1);
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  var streamMin5 = await client.SubscribeRealtimeDataAsync(requestId, ActivePair.EURUSD, TimeFrame.Min5);

  streamMin5.Merge(streamMin1)
      .Subscribe(candleInfo => {
          _logger.LogInformation($"Agora {ActivePair.EURUSD} {candleInfo.TimeFrame} : Bid={candleInfo.Bid}\t Ask={candleInfo.Ask}\t");
  });

  // Remove assinatura do par, e não irá mais receber dados em tempo real para impressão min5 no console
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty); // Novo
  await api.UnSubscribeRealtimeData(requestId, ActivePair.EURUSD, TimeFrame.Min5);

  // Pega a lista de todos os alertas definidos
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
  var alerts = await client.GetAlerts(requestId);
  _logger.Information(JsonConvert.SerializeObject(alerts))

  // Cria Alerta
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
  ActivePair activeId = ActivePair.EURAUD;
  InstrumentType instrumentType = InstrumentType.DigitalOption;
  double value = 200.10;
  int activations = 0; // 1 - For one time OR 2 - For all time
  var alertCreated = await client.CreateAlert(requestId

  // Altera alerta pelo ID
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
  long alertId = alertCreated.Id; // Get id alert created this sample
  ActivePair newActiveId = ActivePair.EURAUD;
  InstrumentType newInstrumentType = InstrumentType.DigitalOption;
  double newValue = 300.51;
  int newActivations = 0; // 1 - For one time OR 2 - For all time
  var alertUpdated = await client.UpdateAlert(requestId, alertId, newActiveId, newInstrumentType, newValue, newActivations);
  _logger.Information(JsonConvert.SerializeObject(alertUpdated));

  // Deletar Alerta
  requestId = Guid.NewGuid().ToString().Replace("-", string.Empty);
  alertId = alertCreated.Id; // Get id alert created this sample
  var alertDelete = await client.DeleteAlert(requestId, alertId);
  _logger.Information(JsonConvert.SerializeObject(alertDelete));

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
        await api.BuyAsync(requestId, ActivePair.EURUSD, (decimal)1.5, OrderDirection.Call, exp);
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

Se de alguma forma ajudei você com qualquer um dos conteúdos que foi disponibilizado, favor ajude também criando um pull-request más, também agradeceria muito seu apoio me pagando um café!!! :) . <br>
<a href="https://buymeacoffee.com/jorgesouza" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/black_img.png" alt="Buy Me A Coffee" style="height: auto !important;width: auto !important;" ></a> Jorge Beserra (Este Repositório)<br>
<a href="https://www.buymeacoffee.com/6VF3XHb" target="_blank"><img src="https://www.buymeacoffee.com/assets/img/custom_images/black_img.png" alt="Buy Me A Coffee" style="height: auto !important;width: auto !important;" ></a> MongkonEiadon (Repositório Base) 
