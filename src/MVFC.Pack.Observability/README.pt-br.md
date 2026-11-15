# MVFC.Pack.Observability

> 🇺🇸 [Read in English](README.md) · [← Voltar ao MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.Observability)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Observability)

Metapackage para observabilidade — tracing distribuído, métricas, instrumentação automática
via OpenTelemetry e service discovery. Essencial para microsserviços e aplicações distribuídas.

## Motivação

Em arquiteturas cloud-native e de microsserviços, observabilidade não é opcional. Você precisa
de traces distribuídos para acompanhar uma requisição entre serviços, métricas de runtime
para detectar pressão de memória ou esgotamento de thread pool, e resolução dinâmica de serviços entre contêineres.

O **MVFC.Pack.Observability** entrega o stack completo de instrumentação OpenTelemetry e service
discovery em uma única referência com versões fixadas. (Para resiliência HTTP, consulte `MVFC.Pack.HttpClient`).

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
    http.AddServiceDiscovery());
```

## Pacotes Inclusos

| Pacote | Versão |
|---|---|
| Microsoft.Extensions.ServiceDiscovery | 9.5.2 (net9) / 10.11.0 (net10) / 11.0.0 (net11) |
| OpenTelemetry.Exporter.OpenTelemetryProtocol | 1.20.1 (net9) / 1.21.0 (net10/11) |
| OpenTelemetry.Extensions.Hosting | 1.20.1 (net9) / 1.21.0 (net10/11) |
| OpenTelemetry.Instrumentation.AspNetCore | 1.20.1 (net9) / 1.21.0 (net10/11) |
| OpenTelemetry.Instrumentation.Http | 1.20.1 (net9) / 1.21.0 (net10/11) |
| OpenTelemetry.Instrumentation.Runtime | 1.20.1 (net9) / 1.21.0 (net10/11) |

## Licença

[Apache-2.0](../../LICENSE)
