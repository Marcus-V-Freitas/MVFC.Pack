# MVFC.Pack.IoC

> 🇧🇷 [Leia em Português](README.pt-br.md) · [← Back to MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.IoC)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.IoC)

Metapackage for Dependency Injection setup — source-generated mediator registration,
automatic service scanning, and FluentValidation DI integration.

## Motivation

Configuring the IoC container in a modern .NET 9+ microservice involves key repetitive
steps: registering MediatR handlers, wiring FluentValidation into DI, and scanning and
registering services automatically without reflection penalties.

**MVFC.Pack.IoC** centralizes these IoC capabilities. The source generators activate at compile time —
meaning zero reflection overhead at runtime. (For resilient HTTP clients and HttpClientFactory, see `MVFC.Pack.HttpClient`).

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
```

## Included Packages

| Package | Version |
|---|---|
| MediatR | 12.5.0 |
| ServiceScan.SourceGenerator | 3.2.2 |
| FluentValidation.DependencyInjectionExtensions | 12.2.0 |

## License

[Apache-2.0](../../LICENSE)
