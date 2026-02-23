# MVFC.Pack.Observability

## Sobre

O **MVFC.Pack.Observability** é um pacote (metapackage) para padronizar a observabilidade em aplicações .NET 10. Ele centraliza as ferramentas de tracing distribuído, métricas, service discovery e resiliência HTTP.

---

## Instalação (NuGet)

Você pode instalar o pacote diretamente via CLI:

```bash
dotnet add package MVFC.Pack.Observability
```

---

## Como Usar

Sendo um metapackage, ao instalá-lo no seu projeto, todas as bibliotecas subjacentes ficam disponíveis para uso imediato em seu código, sem a necessidade de referenciá-las individualmente no `.csproj`. As dependências do OpenTelemetry, Service Discovery e resiliência HTTP estarão prontas para ser configuradas via injeção de dependência.

---

## Pacotes Inclusos e Versões

Abaixo estão as bibliotecas inclusas neste pacote, bem como suas respectivas versões.

| Pacote | Versão |
| ------ | ------ |
| Microsoft.Extensions.Http.Resilience | 10.3.0 |
| Microsoft.Extensions.ServiceDiscovery | 10.3.0 |
| OpenTelemetry.Exporter.OpenTelemetryProtocol | 1.15.0 |
| OpenTelemetry.Extensions.Hosting | 1.15.0 |
| OpenTelemetry.Instrumentation.AspNetCore | 1.15.0 |
| OpenTelemetry.Instrumentation.Http | 1.15.0 |
| OpenTelemetry.Instrumentation.Runtime | 1.15.0 |

---

## Motivação

Entregar observabilidade completa para suas aplicações com tracing distribuído, métricas e instrumentação automática (OpenTelemetry), resolução dinâmica de serviços (Service Discovery) e resiliência para chamadas HTTP (Polly). Essencial para ambientes de microsserviços e arquiteturas cloud-native.

---

## Licença

Este projeto é licenciado sob a licença **Apache License 2.0**. Consulte o arquivo [LICENSE](../../LICENSE) para obter mais detalhes.
