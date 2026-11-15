# MVFC.Pack.HttpClient

> 🇧🇷 [Leia em Português](README.pt-br.md) · [← Back to MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.HttpClient)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.HttpClient)

Metapackage providing dependencies for typed HTTP clients using Refit, HttpClientFactory, and HTTP resilience policies in .NET 9 and 10 applications.

## What It Is and What It Is Not

- **What it is:** A passive dependency metapackage that consolidates and pins the necessary packages to declare typed REST clients (Refit + HttpClientFactory) and configure resilience pipelines (`Microsoft.Extensions.Http.Resilience`).
- **What it is not:** An HTTP framework, wrapper library, or automatic runtime service registrar. It contains no runtime code, creates no handlers, and registers no services automatically. The consuming application decides all registrations and pipeline configurations explicitly.

## Installation

```sh
dotnet add package MVFC.Pack.HttpClient
```

## Included Packages

| Package | Version | Purpose |
|---|---|---|
| `Refit` | 8.0.0 (net9) / 16.4.0 (net10/11) | Declarative, typed REST client for .NET. |
| `Refit.HttpClientFactory` | 8.0.0 (net9) / 16.4.0 (net10/11) | Integrates Refit clients with `IHttpClientFactory`. |
| `Microsoft.Extensions.Http` | 9.0.2 (net9) / 10.0.14 (net10) / 11.0.0 (net11) | Core `IHttpClientFactory` abstractions and client configuration. |
| `Microsoft.Extensions.Http.Resilience` | 9.2.0 (net9) / 10.11.0 (net10) / 11.0.0 (net11) | Standard resilience pipelines (retry, circuit breaker, timeout, rate limiter) based on Polly. |

## Quick Start

In your application startup / DI configuration:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Refit;

// 1. Define your typed client interface
public interface IPingApi
{
    [Get("/ping")]
    Task<string> PingAsync(CancellationToken cancellationToken = default);
}

// 2. Register with HttpClientFactory and resilience
public static class HttpClientSetup
{
    public static void Configure(IServiceCollection services)
    {
        services.AddRefitClient<IPingApi>()
            .ConfigureHttpClient(client =>
            {
                client.BaseAddress = new Uri("https://api.example.com");
            })
            .AddStandardResilienceHandler();
    }
}
```

> [!WARNING]
> **Resilience & Idempotency Warning:**  
> The standard resilience handler includes retry policies that may not be safe for non-idempotent HTTP methods (such as `POST` or operations with side-effects). Ensure your retry strategy is explicitly adapted to each endpoint's semantics to prevent unintentional duplicate requests.

## Compatibility

- Supported target frameworks in this release: `net9.0;net10.0`.
- Compatibility with .NET 9 is aligned with the current repository product line and does not constitute a long-term support commitment.

## License

[Apache-2.0](../../LICENSE)
