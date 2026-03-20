# MVFC.Pack

> 🇧🇷 [Leia em Português](README.pt-br.md)

[![CI](https://github.com/Marcus-V-Freitas/MVFC.Pack/actions/workflows/ci.yml/badge.svg)](https://github.com/Marcus-V-Freitas/MVFC.Pack/actions/workflows/ci.yml)
[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
[![NuGet](https://img.shields.io/nuget/v/MVFC.Pack.Api?label=MVFC.Pack.Api)](https://www.nuget.org/packages/MVFC.Pack.Api)

A collection of opinionated metapackages to standardize and accelerate .NET 9 | 10 development.
Instead of installing the same libraries repeatedly across every microservice or project,
reference the MVFC.Pack package that matches your layer — versions are pinned and the best
tooling is included by default.

## Motivation

In any multi-project organization, you inevitably face:

- **Version drift**: different projects pulling incompatible versions of the same library.
- **Bootstrapping tax**: every new service requires the same `dotnet add package` ritual.
- **Inconsistency**: different developers choose different logging, validation or testing tools.

**MVFC.Pack** eliminates this by providing a curated set of metapackages — one per layer —
that lock versions, enforce tooling standards and get your project running immediately.

---

## Available Packages

| Package | Service / Purpose | Downloads |
|---|---|---|
| [MVFC.Pack.Api](src/MVFC.Pack.Api/README.md) | Standardized ASP.NET Core API development | ![Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Api) |
| [MVFC.Pack.Domain](src/MVFC.Pack.Domain/README.md) | Domain layer abstractions (MediatR, Refit, Validation) | ![Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Domain) |
| [MVFC.Pack.IoC](src/MVFC.Pack.IoC/README.md) | IoC with source-generated scanning and resilience | ![Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.IoC) |
| [MVFC.Pack.Observability](src/MVFC.Pack.Observability/README.md) | Telemetry, metrics and service discovery | ![Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Observability) |
| [MVFC.Pack.Cache](src/MVFC.Pack.Cache/README.md) | Distributed caching (Redis + HybridCache) | ![Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Cache) |
| [MVFC.Pack.Analyzers](src/MVFC.Pack.Analyzers/README.md) | Static analysis for code quality | ![Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Analyzers) |
| [MVFC.Pack.Testing](src/MVFC.Pack.Testing/README.md) | Testing ecosystem (xUnit v3, FluentAssertions) | ![Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Testing) |

---

## Installation

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

Metapackages require no extra configuration — install and use:

```csharp
// MVFC.Pack.Api — Serilog, OpenApi, JWT, HealthChecks ready
builder.Host.UseSerilog();
builder.Services.AddOpenApi();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
       .AddJwtBearer();

// MVFC.Pack.Testing — xUnit v3, FluentAssertions, NSubstitute, Testcontainers ready
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
// activate automatically at build time, no code required.
```

---

## Package Contents

### MVFC.Pack.Api

| Package | Version |
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

| Package | Version |
|---|---|
| MediatR | 12.5.0 |
| Refit | 10.0.1 |
| Refit.HttpClientFactory | 10.0.1 |
| FluentResults | 4.0.0 |
| FluentValidation | 12.1.1 |

### MVFC.Pack.IoC

| Package | Version |
|---|---|
| MediatR | 12.5.0 |
| ServiceScan.SourceGenerator | 2.4.1 |
| FluentValidation.DependencyInjectionExtensions | 12.1.1 |
| Microsoft.Extensions.Http | 10.0.3 |
| Microsoft.Extensions.Http.Resilience | 10.3.0 |

### MVFC.Pack.Observability

| Package | Version |
|---|---|
| Microsoft.Extensions.Http.Resilience | 10.3.0 |
| Microsoft.Extensions.ServiceDiscovery | 10.3.0 |
| OpenTelemetry.Exporter.OpenTelemetryProtocol | 1.15.0 |
| OpenTelemetry.Extensions.Hosting | 1.15.0 |
| OpenTelemetry.Instrumentation.AspNetCore | 1.15.0 |
| OpenTelemetry.Instrumentation.Http | 1.15.0 |
| OpenTelemetry.Instrumentation.Runtime | 1.15.0 |

### MVFC.Pack.Cache

| Package | Version |
|---|---|
| StackExchange.Redis | 2.11.3 |
| Microsoft.Extensions.Caching.StackExchangeRedis | 10.0.3 |
| Microsoft.Extensions.Caching.Hybrid | 10.3.0 |

### MVFC.Pack.Analyzers

| Package | Version |
|---|---|
| Microsoft.CodeAnalysis.NetAnalyzers | 10.0.103 |
| SonarAnalyzer.CSharp | 10.19.0.132793 |
| Roslynator.Analyzers | 4.15.0 |
| Meziantou.Analyzer | 3.0.15 |

### MVFC.Pack.Testing

| Package | Version |
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

## Package Purpose

- **`MVFC.Pack.Api`** — Structured logs (Serilog), API docs (OpenApi/Scalar), versioning
  (Asp.Versioning), JWT auth and standardized Health Checks out of the box.

- **`MVFC.Pack.Domain`** — CQRS via MediatR, declarative HTTP clients (Refit), error handling
  without exceptions (FluentResults) and fluent object validation (FluentValidation).

- **`MVFC.Pack.IoC`** — Source-generated mediator registration for maximum performance,
  automatic service scanning (ServiceScan), FluentValidation DI integration and resilient HTTP
  clients via HttpClientFactory + Polly.

- **`MVFC.Pack.Observability`** — Full observability stack: distributed tracing, metrics,
  automatic instrumentation (OpenTelemetry), dynamic service resolution (Service Discovery)
  and HTTP resilience. Essential for microservices and cloud-native architectures.

- **`MVFC.Pack.Cache`** — Distributed cache with Redis (StackExchange), aligned with .NET
  native abstractions and the new Hybrid Cache for flexible L1/L2 strategies.

- **`MVFC.Pack.Analyzers`** — Continuous code quality enforcement at build time via
  SonarAnalyzer, Roslynator and Meziantou.Analyzer. No configuration needed — rules activate
  automatically.

- **`MVFC.Pack.Testing`** — Full testing ecosystem: xUnit v3, NSubstitute, Bogus + AutoBogus
  for realistic fake data, FluentAssertions for expressive assertions and Testcontainers for
  disposable infrastructure.

---

## Project Structure

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

## Requirements

- .NET 9+

---

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md).

---

## License

[Apache-2.0](LICENSE)
