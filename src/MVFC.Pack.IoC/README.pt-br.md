# MVFC.Pack.IoC

> 🇺🇸 [Read in English](README.md) · [← Voltar ao MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.IoC)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.IoC)

Metapackage para configuração de Injeção de Dependência — registro do mediator via Source
Generator, varredura automática de serviços e integração do FluentValidation com DI.

## Motivação

Configurar o container IoC em um microsserviço .NET 9+ moderno envolve passos repetitivos
essenciais: registrar handlers do MediatR, integrar o FluentValidation ao DI e varrer e
registrar serviços automaticamente em tempo de compilação sem custos de reflection.

O **MVFC.Pack.IoC** centraliza essas configurações. Os source generators ativam em tempo de compilação
— zero overhead de reflection em runtime. (Para clientes HTTP resilientes e HttpClientFactory, consulte `MVFC.Pack.HttpClient`).

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
```

## Pacotes Inclusos

| Pacote | Versão |
|---|---|
| MediatR | 12.5.0 |
| ServiceScan.SourceGenerator | 3.2.2 |
| FluentValidation.DependencyInjectionExtensions | 12.2.0 |

## Licença

[Apache-2.0](../../LICENSE)
