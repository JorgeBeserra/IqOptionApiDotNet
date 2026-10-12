# Receber resultados de opções binárias/turbo

A inicialização do WebSocket envia `setOptions` com `msg.sendResults = true`
para habilitar os eventos `option-opened` e `option-closed` da sessão. O resultado
continua disponível por `client.WsClient.ClosedOptionObservable()`.

Crie e mantenha uma única assinatura antes de enviar a compra:

```csharp
using var subscription = client.WsClient.ClosedOptionObservable()
    .Subscribe(result =>
    {
        Console.WriteLine($"Opção {result.OptionId}: {result.Result}");
        // Compare result.OptionId com o ID da sua ordem para correlacionar resultados.
    });

var buyResult = await client.BuyAsync(requestId, BalanceType.Practice,
    ActivePair.EURUSD_op, 1m, OrderDirection.Call, expiration);
// Mantenha subscription viva enquanto aguarda o fechamento.
```

`Subscribe().Dispose()` cria e descarta outra assinatura; não descarta aquela
que contém seu callback. Evite recriar assinaturas em um laço.

O comando vale para a sessão do socket. Se reconectar o socket manualmente,
habilite novamente antes de enviar ordens:

```csharp
await client.WsClient.SetOptionResultsAsync(Guid.NewGuid().ToString("N"));
```

O método retorna após enviar o comando, sem afirmar que houve confirmação do
servidor. Não adiciona reconexão automática nem converte eventos digitais de
portfólio em resultados binários. Para posições digitais, use o fluxo existente
`PositionChangedObservable()`.

Referência do protocolo: a implementação Python envia o mesmo comando em
[api.py](https://github.com/Lu-Yi-Hsun/iqoptionapi/blob/master/iqoptionapi/api.py)
e o habilita após a conexão em
[stable_api.py](https://github.com/Lu-Yi-Hsun/iqoptionapi/blob/master/iqoptionapi/stable_api.py).
Esta referência confirma a implementação de outro cliente, não substitui uma
captura autenticada do protocolo atual.

Verificação local: um executável isolado compilou os arquivos reais da mensagem,
do dispatcher, do observable e dos modelos, com Newtonsoft.Json 13.0.3 e
System.Reactive 6.0.1. Passaram dois casos de payload (habilitar/desabilitar) e três
casos JSON → dispatcher → observable (`win`, `loose`, `equal`), preservando o ID
da opção e do saldo. Transporte/logging foram substituídos por implementações
locais no executável. Os cinco casos também têm testes NUnit no projeto.
A suíte completa e a integração autenticada ainda não foram executadas.
