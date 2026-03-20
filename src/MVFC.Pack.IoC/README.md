# MVFC.Pack.IoC

> 🇧🇷 [Leia em Português](README.pt-br.md) · [← Back to MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.IoC)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.IoC)

Metapackage for Dependency Injection setup — source-generated mediator registration,
automatic service scanning, FluentValidation DI integration and resilient HTTP clients.

## Motivation

Configuring the IoC container in a modern- .NET 9+
microservice involves the same repetitive
steps: registering MediatR handlers, wiring FluentValidation into DI, scanning and
registering services automatically, and building resilient HTTP clients with Polly.

**MVFC.Pack.IoC** centralizes all of this. The source generators activate at compile time —
meaning zero reflection overhead at runtime — and the resilience pipeline follows the
.NET standard patterns out of the box.

## Installation

```sh
dotnet add package MVFC.Pack.IoC
```

## Quick Start

```csharp
// 1. MediatR registration
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<Program>());

// 2. Automatic service scanning via ServiceScan source generator
// Decorate your partial class and all matching services are registered at compile time
[RegisterServices]
public partial class ServiceRegistrar;

// 3. FluentValidation DI integration
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// 4. Resilient HTTP client with HttpClientFactory + Polly
builder.Services.AddHttpClient<IPaymentApi>(client =>
    client.BaseAddress = new Uri(builder.Configuration["PaymentApi:BaseUrl"]!))
    .AddStandardResilienceHandler();
```

## Included Packages

| Package | Version |
|---|---|
| MediatR | 12.5.0 |
| ServiceScan.SourceGenerator | 2.4.1 |
| FluentValidation.DependencyInjectionExtensions | 12.1.1 |
| Microsoft.Extensions.Http | 10.0.3 |
| Microsoft.Extensions.Http.Resilience | 10.3.0 |

## License

[Apache-2.0](../../LICENSE)
