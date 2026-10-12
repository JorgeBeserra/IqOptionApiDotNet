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

Em Settings → Secrets and variables → Actions, cadastre o secret de repositório
`NUGET_API_KEY`. Seu valor deve ser uma API key do NuGet.org autorizada a publicar
novas versões de `IqOptionApiDotNet`. Não adicione essa chave ao código.
`GITHUB_TOKEN` não autentica publicação no NuGet.org.

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
