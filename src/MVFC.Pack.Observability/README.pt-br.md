# MVFC.Pack.Observability

> 🇺🇸 [Read in English](README.md) · [← Voltar ao MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.Observability)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Observability)

Metapackage para observabilidade — tracing distribuído, métricas, instrumentação automática
via OpenTelemetry, service discovery e resiliência HTTP. Essencial para microsserviços e
aplicações distribuídas.

## Motivação

Em arquiteturas cloud-native e de microsserviços, observabilidade não é opcional. Você precisa
de traces distribuídos para acompanhar uma requisição entre serviços, métricas de runtime
para detectar pressão de memória ou esgotamento de thread pool, e clientes HTTP resilientes
para tolerar falhas transitórias.

Cada um desses requisitos exige seu próprio conjunto de pacotes, versões e boilerplate de
configuração. O **MVFC.Pack.Observability** entrega o stack completo de instrumentação
OpenTelemetry, service discovery e resiliência HTTP em uma única referência com versões fixadas.

## Instalação

```sh
dotnet add package MVFC.Pack.Observability
```

## Quick Start

```csharp
builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing
        .AddAspNetCoreInstrumentation()
        .AddHttpClientInstrumentation()
        .AddOtlpExporter(o =>
            o.Endpoint = new Uri(builder.Configuration["Otel:Endpoint"]!)))
    .WithMetrics(metrics => metrics
        .AddAspNetCoreInstrumentation()
        .AddRuntimeInstrumentation()
        .AddOtlpExporter());

builder.Services.AddServiceDiscovery();

builder.Services.ConfigureHttpClientDefaults(http =>
    http.AddServiceDiscovery()
        .AddStandardResilienceHandler());
```

## Pacotes Inclusos

| Pacote | Versão |
|---|---|
| Microsoft.Extensions.Http.Resilience | 10.3.0 |
| Microsoft.Extensions.ServiceDiscovery | 10.3.0 |
| OpenTelemetry.Exporter.OpenTelemetryProtocol | 1.15.0 |
| OpenTelemetry.Extensions.Hosting | 1.15.0 |
| OpenTelemetry.Instrumentation.AspNetCore | 1.15.0 |
| OpenTelemetry.Instrumentation.Http | 1.15.0 |
| OpenTelemetry.Instrumentation.Runtime | 1.15.0 |

## Licença

[Apache-2.0](../../LICENSE)
