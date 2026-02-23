# MVFC.Pack.Api

## Sobre

O **MVFC.Pack.Api** é um pacote (metapackage) criado para padronizar e acelerar o desenvolvimento de APIs no ecossistema .NET 10. Ele centraliza toda a base para a criação de APIs ricas e robustas, garantindo que as versões das dependências de API estejam sempre alinhadas e adotando as melhores ferramentas do mercado por padrão.

---

## Instalação (NuGet)

Você pode instalar o pacote diretamente via CLI:

```bash
dotnet add package MVFC.Pack.Api
```

---

## Como Usar

Sendo um metapackage, ao instalá-lo no seu projeto, todas as bibliotecas subjacentes ficam disponíveis para uso imediato em seu código, sem a necessidade de referenciá-las individualmente no `.csproj`. As dependências (`Refit`, `Serilog`, `FluentResults`, etc.) estarão prontas para serem importadas usando `using Namespace;`.

---

## Pacotes Inclusos e Versões

Abaixo estão as bibliotecas inclusas neste pacote, bem como suas respectivas versões.

| Pacote | Versão |
| ------ | ------ |
| Refit | 10.0.1 |
| Refit.HttpClientFactory | 10.0.1 |
| FluentValidation | 12.1.1 |
| FluentResults | 4.0.0 |
| Serilog.AspNetCore | 10.0.0 |
| Serilog.Sinks.Console | 6.1.1 |
| Microsoft.Extensions.Http.Resilience | 10.3.0 |
| Microsoft.AspNetCore.OpenApi | 10.0.3 |
| Microsoft.AspNetCore.Authentication.JwtBearer | 10.0.3 |

---

## Motivação

Centralizar toda a base para a criação de APIs ricas e robustas. Ao invés de decorar e instalar diversas bibliotecas na criação de uma API, este pacote já traz ferramentas para criar clientes HTTP resilientes e declarativos (Refit/Polly), padronizações de resultado e erro sem exceções vazadas (FluentResults e FluentValidation), geração de documentação das rotas (OpenApi), registro de logs estruturados (Serilog) e segurança com JWT.

---

## Licença

Este projeto é licenciado sob a licença **Apache License 2.0**. Consulte o arquivo [LICENSE](../../LICENSE) para obter mais detalhes.
