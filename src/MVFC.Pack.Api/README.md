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

Sendo um metapackage, ao instalá-lo no seu projeto, todas as bibliotecas subjacentes ficam disponíveis para uso imediato em seu código, sem a necessidade de referenciá-las individualmente no `.csproj`.

---

## Pacotes Inclusos e Versões

Abaixo estão as bibliotecas inclusas neste pacote, bem como suas respectivas versões.

| Pacote | Versão |
| ------ | ------ |
| Serilog.AspNetCore | 10.0.0 |
| Serilog.Sinks.File | 7.0.0 |
| Serilog.Sinks.Console | 6.1.1 |
| Microsoft.AspNetCore.OpenApi | 10.0.3 |
| Microsoft.AspNetCore.Authentication.JwtBearer | 10.0.3 |
| Asp.Versioning.Http | 8.1.1 |
| AspNetCore.Scalar | 1.2.0 |
| Microsoft.Extensions.Diagnostics.HealthChecks | 10.0.3 |
| AspNetCore.HealthChecks.UI.Client | 9.0.0 |

---

## Motivação

Centralizar toda a base para a criação de APIs ricas e robustas. Ao invés de decorar e instalar diversas bibliotecas na criação de uma API, este pacote já traz ferramentas para logs estruturados (Serilog), documentação de rotas (OpenApi/Scalar), versionamento de API (Asp.Versioning), segurança com JWT e Health Checks padronizados.

---

## Licença

Este projeto é licenciado sob a licença **Apache License 2.0**. Consulte o arquivo [LICENSE](../../LICENSE) para obter mais detalhes.
