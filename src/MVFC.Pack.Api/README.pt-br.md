# MVFC.Pack.Api

> 🇺🇸 [Read in English](README.md) · [← Voltar ao MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.Api)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Api)

Metapackage para APIs ASP.NET Core — logs estruturados, documentação OpenAPI, autenticação
JWT, versionamento de API e Health Checks, com versões fixadas e pronto para uso.

## Motivação

Construir APIs prontas para produção em .NET 9+
significa instalar e configurar o mesmo conjunto
de bibliotecas a cada novo projeto: um sink de log, um provedor OpenAPI, um middleware JWT,
uma biblioteca de versionamento e endpoints de health check — cada um com sua própria versão
para manter sincronizada.

O **MVFC.Pack.Api** instala tudo em uma única referência e fixa cada versão, para que você
comece com uma base de API consistente e testada desde a primeira linha de código.

## Instalação

```sh
dotnet add package MVFC.Pack.Api
```

## Quick Start

```csharp
// Program.cs — tudo disponível após a instalação, sem pacotes adicionais

builder.Host.UseSerilog((ctx, cfg) =>
    cfg.ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddOpenApi();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration["Auth:Authority"];
        options.Audience  = builder.Configuration["Auth:Audience"];
    });
builder.Services.AddHealthChecks();

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();
app.MapHealthChecks("/health");
app.UseAuthentication();
app.UseAuthorization();
```

## Pacotes Inclusos

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

## Licença

[Apache-2.0](../../LICENSE)
