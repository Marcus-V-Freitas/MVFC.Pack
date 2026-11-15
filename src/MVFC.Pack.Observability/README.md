# MVFC.Pack.Observability

> 🇧🇷 [Leia em Português](README.pt-br.md) · [← Back to MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.Observability)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Observability)

Metapackage for observability — distributed tracing, metrics, automatic instrumentation
via OpenTelemetry and service discovery. Essential for microservices and cloud-native architectures.

## Motivation

In cloud-native and microservices architectures, observability is not optional. You need
distributed traces to follow a request across services, runtime metrics to detect memory
pressure or thread pool exhaustion, and dynamic service resolution across containers.

**MVFC.Pack.Observability** ships the full OpenTelemetry instrumentation stack and service discovery
as a single, version-locked reference. (For HTTP client resilience policies, see `MVFC.Pack.HttpClient`).

## Installation

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

## Included Packages

| Package | Version |
|---|---|
| Microsoft.Extensions.ServiceDiscovery | 9.5.2 (net9) / 10.11.0 (net10) / 11.0.0 (net11) |
| OpenTelemetry.Exporter.OpenTelemetryProtocol | 1.20.1 (net9) / 1.21.0 (net10/11) |
| OpenTelemetry.Extensions.Hosting | 1.20.1 (net9) / 1.21.0 (net10/11) |
| OpenTelemetry.Instrumentation.AspNetCore | 1.20.1 (net9) / 1.21.0 (net10/11) |
| OpenTelemetry.Instrumentation.Http | 1.20.1 (net9) / 1.21.0 (net10/11) |
| OpenTelemetry.Instrumentation.Runtime | 1.20.1 (net9) / 1.21.0 (net10/11) |

## License

[Apache-2.0](../../LICENSE)
