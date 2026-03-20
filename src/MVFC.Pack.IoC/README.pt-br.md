# MVFC.Pack.IoC

> 🇺🇸 [Read in English](README.md) · [← Voltar ao MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.IoC)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.IoC)

Metapackage para configuração de Injeção de Dependência — registro do mediator via Source
Generator, varredura automática de serviços, integração do FluentValidation com DI e
clientes HTTP resilientes.

## Motivação

Configurar o container IoC em um microsserviço .NET moderno envolve os mesmos passos
repetitivos: registrar handlers do MediatR, integrar o FluentValidation ao DI, varrer e
registrar serviços automaticamente, e construir clientes HTTP resilientes com Polly.

O **MVFC.Pack.IoC** centraliza tudo isso. Os source generators ativam em tempo de compilação
— zero overhead de reflection em runtime — e o pipeline de resiliência segue os padrões
nativos do- .NET 9+

## Instalação

```sh
dotnet add package MVFC.Pack.IoC
```

## Quick Start

```csharp
// 1. Registro do MediatR
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssemblyContaining<Program>());

// 2. Varredura automática via ServiceScan source generator
// Decore sua classe parcial e todos os serviços correspondentes são registrados em compilação
[RegisterServices]
public partial class ServiceRegistrar;

// 3. Integração do FluentValidation com DI
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

// 4. Cliente HTTP resiliente com HttpClientFactory + Polly
builder.Services.AddHttpClient<IPaymentApi>(client =>
    client.BaseAddress = new Uri(builder.Configuration["PaymentApi:BaseUrl"]!))
    .AddStandardResilienceHandler();
```

## Pacotes Inclusos

| Pacote | Versão |
|---|---|
| MediatR | 12.5.0 |
| ServiceScan.SourceGenerator | 2.4.1 |
| FluentValidation.DependencyInjectionExtensions | 12.1.1 |
| Microsoft.Extensions.Http | 10.0.3 |
| Microsoft.Extensions.Http.Resilience | 10.3.0 |

## Licença

[Apache-2.0](../../LICENSE)
