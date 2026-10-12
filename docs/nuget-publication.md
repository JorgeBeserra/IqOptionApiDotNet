# Publicação no NuGet.org

O pacote `IqOptionApiDotNet` já existe no NuGet.org. O workflow anterior não o
publicava: continha placeholders e não executava `dotnet nuget push`.

O workflow `.github/workflows/release.yml` agora publica após um push na `master`
que altera a versão explícita no projeto `src/IqOptionApiDotNet/IqOptionApiDotNet.csproj`.
O detector compara o estado anterior ao push com o commit atual, inclusive em
pushes com múltiplos commits. `PackageVersion`, quando definido, tem precedência
sobre `Version`. Alterar apenas `AssemblyVersion` ou `FileVersion` não publica.

A sequência é detectar versão → restaurar → testar → empacotar a biblioteca →
salvar artefato → publicar no NuGet.org. Falhas interrompem a publicação.

## Configuração necessária

Cadastre uma política em https://www.nuget.org/account/trustedpublishing:

- Repository Owner: `JorgeBeserra`
- Repository: `IqOptionApiDotNet`
- Workflow File: `release.yml` (somente o nome)
- Environment: vazio (o job não usa um environment)
- Proprietário NuGet: a conta que tem permissão sobre `IqOptionApiDotNet`

O workflow usa `NuGet/login@v1` e `id-token: write` para obter uma chave temporária
imediatamente antes do push. Não exige o secret `NUGET_API_KEY`.
O usuário NuGet padrão é `Sabidos`, conforme a política informada. Caso o nome de
login seja outro (por exemplo, proprietário é uma organização), defina a variável
de repositório `NUGET_USER` em Settings → Secrets and variables → Actions →
Variables. Use o nome de usuário NuGet, não o e-mail.

Para publicar, altere `<Version>3.0.2</Version>` para uma nova versão no projeto e
mescle a alteração na `master`. A versão 3.0.2 já foi publicada e não será
sobrescrita. Este PR não aumenta a versão nem publica um pacote imediatamente.

Para repetir uma publicação que falhou após a mudança de versão, use Actions →
Publish to NuGet.org → Run workflow, selecionando `master`. O disparo manual usa
a versão atual do projeto; `--skip-duplicate` torna repetidas tentativas da mesma
versão tolerantes a um pacote já existente. Execuções são serializadas e uma
publicação em andamento não é cancelada por um novo push.

O workflow não publica a partir de pull requests nem de outras branches. Os
pacotes produzidos ficam disponíveis no artefato `nuget-package` da execução.
