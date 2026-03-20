# MVFC.Pack

> 🇺🇸 [Read in English](README.md)

[![CI](https://github.com/Marcus-V-Freitas/MVFC.Pack/actions/workflows/ci.yml/badge.svg)](https://github.com/Marcus-V-Freitas/MVFC.Pack/actions/workflows/ci.yml)
[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
[![NuGet](https://img.shields.io/nuget/v/MVFC.Pack.Api?label=MVFC.Pack.Api)](https://www.nuget.org/packages/MVFC.Pack.Api)

Uma coleção de metapackages opinados para padronizar e acelerar o desenvolvimento .NET 9+.
Em vez de instalar as mesmas bibliotecas repetidamente em cada microsserviço ou projeto,
basta referenciar o pacote MVFC.Pack correspondente à sua camada — as versões são fixadas e
as melhores ferramentas já vêm incluídas por padrão.

## Motivação

Em qualquer organização com múltiplos projetos, inevitavelmente surgem:

- **Divergência de versões**: projetos diferentes puxando versões incompatíveis da mesma biblioteca.
- **Custo de setup**: cada novo serviço exige o mesmo ritual de `dotnet add package`.
- **Inconsistência**: diferentes desenvolvedores escolhem bibliotecas diferentes de log, validação ou testes.

O **MVFC.Pack** elimina esses problemas fornecendo um conjunto de metapackages — um por camada —
que fixam versões, impõem padrões de tooling e colocam seu projeto em funcionamento imediatamente.

---

## Pacotes Disponíveis

| Pacote | Serviço / Propósito | Downloads |
|---|---|---|
| [MVFC.Pack.Api](src/MVFC.Pack.Api/README.pt-br.md) | Desenvolvimento padronizado de APIs ASP.NET Core | ![Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Api) |
| [MVFC.Pack.Domain](src/MVFC.Pack.Domain/README.pt-br.md) | Abstrações de domínio (MediatR, Refit, Validação) | ![Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Domain) |
| [MVFC.Pack.IoC](src/MVFC.Pack.IoC/README.pt-br.md) | IoC com scanning via source-generator e resiliência | ![Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.IoC) |
| [MVFC.Pack.Observability](src/MVFC.Pack.Observability/README.pt-br.md) | Telemetria, métricas e service discovery | ![Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Observability) |
| [MVFC.Pack.Cache](src/MVFC.Pack.Cache/README.pt-br.md) | Cache distribuído (Redis + HybridCache) | ![Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Cache) |
| [MVFC.Pack.Analyzers](src/MVFC.Pack.Analyzers/README.pt-br.md) | Análise estática para qualidade de código | ![Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Analyzers) |
| [MVFC.Pack.Testing](src/MVFC.Pack.Testing/README.pt-br.md) | Ecossistema de testes (xUnit v3, FluentAssertions) | ![Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Testing) |

---

## Instalação

```sh
dotnet add package MVFC.Pack.Api
dotnet add package MVFC.Pack.Domain
dotnet add package MVFC.Pack.IoC
dotnet add package MVFC.Pack.Observability
dotnet add package MVFC.Pack.Cache
dotnet add package MVFC.Pack.Analyzers
dotnet add package MVFC.Pack.Testing
```

---

## Quick Start

Metapackages não exigem configuração adicional — instale e use:

```csharp
// MVFC.Pack.Api — Serilog, OpenApi, JWT, HealthChecks prontos
builder.Host.UseSerilog();
builder.Services.AddOpenApi();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer();

// MVFC.Pack.Testing — xUnit v3, FluentAssertions, NSubstitute, Testcontainers prontos
public class OrderServiceTests
{
    private readonly IOrderRepository _repo = Substitute.For<IOrderRepository>();

    [Fact]
    public async Task CreateOrder_ShouldReturnCreatedOrder()
    {
        var result = await _sut.CreateAsync(new CreateOrderRequest(...));
        result.Should().NotBeNull();
    }
}

// MVFC.Pack.Analyzers — SonarAnalyzer, Roslynator, Meziantou
// ativam automaticamente no build, sem nenhum código adicional.
```

---

## Conteúdo dos Pacotes

### MVFC.Pack.Api

| Pacote | Versão |
|---|---|
| Serilog.AspNetCore | 10.0.0 |
| Serilog.Sinks.File | 7.0.0 |
| Serilog.Sinks.Console | 6.1.1 |
| Microsoft.AspNetCore.OpenApi | 10.0.3 |
| Microsoft.AspNetCore.Authentication.JwtBearer | 10.0.3 |
| Asp.Versioning.Http | 8.1.1 |
| AspNetCore.Scalar | 1.2.0 |
| Microsoft.Extensions.Diagnostics.HealthChecks | 10.0.3 |
| AspNetCore.HealthChecks.UI.Client | 9.0.0 |

### MVFC.Pack.Domain

| Pacote | Versão |
|---|---|
| MediatR | 12.5.0 |
| Refit | 10.0.1 |
| Refit.HttpClientFactory | 10.0.1 |
| FluentResults | 4.0.0 |
| FluentValidation | 12.1.1 |

### MVFC.Pack.IoC

| Pacote | Versão |
|---|---|
| MediatR | 12.5.0 |
| ServiceScan.SourceGenerator | 2.4.1 |
| FluentValidation.DependencyInjectionExtensions | 12.1.1 |
| Microsoft.Extensions.Http | 10.0.3 |
| Microsoft.Extensions.Http.Resilience | 10.3.0 |

### MVFC.Pack.Observability

| Pacote | Versão |
|---|---|
| Microsoft.Extensions.Http.Resilience | 10.3.0 |
| Microsoft.Extensions.ServiceDiscovery | 10.3.0 |
| OpenTelemetry.Exporter.OpenTelemetryProtocol | 1.15.0 |
| OpenTelemetry.Extensions.Hosting | 1.15.0 |
| OpenTelemetry.Instrumentation.AspNetCore | 1.15.0 |
| OpenTelemetry.Instrumentation.Http | 1.15.0 |
| OpenTelemetry.Instrumentation.Runtime | 1.15.0 |

### MVFC.Pack.Cache

| Pacote | Versão |
|---|---|
| StackExchange.Redis | 2.11.3 |
| Microsoft.Extensions.Caching.StackExchangeRedis | 10.0.3 |
| Microsoft.Extensions.Caching.Hybrid | 10.3.0 |

### MVFC.Pack.Analyzers

| Pacote | Versão |
|---|---|
| Microsoft.CodeAnalysis.NetAnalyzers | 10.0.103 |
| SonarAnalyzer.CSharp | 10.19.0.132793 |
| Roslynator.Analyzers | 4.15.0 |
| Meziantou.Analyzer | 3.0.15 |

### MVFC.Pack.Testing

| Pacote | Versão |
|---|---|
| xunit.v3 | 3.2.2 |
| xunit.v3.extensibility.core | 3.2.2 |
| xunit.runner.visualstudio | 3.1.5 |
| Microsoft.NET.Test.Sdk | 18.0.1 |
| FluentAssertions | 7.0.0 |
| NSubstitute | 5.3.0 |
| Microsoft.AspNetCore.Mvc.Testing | 10.0.3 |
| Bogus | 35.6.5 |
| AutoBogus | 2.13.1 |
| Testcontainers | 4.10.0 |

---

## Motivação de Cada Pacote

- **`MVFC.Pack.Api`** — Logs estruturados (Serilog), documentação de rotas (OpenApi/Scalar),
  versionamento (Asp.Versioning), autenticação JWT e Health Checks padronizados prontos para uso.

- **`MVFC.Pack.Domain`** — CQRS via MediatR, clientes HTTP declarativos (Refit), tratamento de
  erros sem exceções (FluentResults) e validação fluente de objetos (FluentValidation).

- **`MVFC.Pack.IoC`** — Registro do mediator via Source Generator para máxima performance,
  varredura automática de serviços (ServiceScan), integração do FluentValidation com DI e
  clientes HTTP resilientes via HttpClientFactory + Polly.

- **`MVFC.Pack.Observability`** — Observabilidade completa: tracing distribuído, métricas,
  instrumentação automática (OpenTelemetry), resolução dinâmica de serviços (Service Discovery)
  e resiliência HTTP. Essencial para microsserviços e arquiteturas cloud-native.

- **`MVFC.Pack.Cache`** — Cache distribuído com Redis (StackExchange), alinhado às abstrações
  nativas do .NET e ao novo Hybrid Cache para estratégias L1/L2 flexíveis.

- **`MVFC.Pack.Analyzers`** — Garantia contínua de qualidade de código em tempo de build via
  SonarAnalyzer, Roslynator e Meziantou.Analyzer. Sem configuração — as regras ativam
  automaticamente.

- **`MVFC.Pack.Testing`** — Ecossistema completo de testes: xUnit v3, NSubstitute, Bogus +
  AutoBogus para dados fictícios realistas, FluentAssertions para asserções expressivas e
  Testcontainers para infraestrutura descartável.

---

## Estrutura do Projeto

```text
src/
  MVFC.Pack.Api/
  MVFC.Pack.Domain/
  MVFC.Pack.IoC/
  MVFC.Pack.Observability/
  MVFC.Pack.Cache/
  MVFC.Pack.Analyzers/
  MVFC.Pack.Testing/
tests/
  MVFC.Pack.Tests/
```

---

## Requisitos

- .NET 9+

---

## Contribuição

Consulte [CONTRIBUTING.md](CONTRIBUTING.md).

---

## Licença

[Apache-2.0](LICENSE)
