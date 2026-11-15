# MVFC.Pack.Api

> 🇧🇷 [Leia em Português](README.pt-br.md) · [← Back to MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.Api)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Api)

Metapackage for ASP.NET Core APIs — structured logging, OpenAPI docs, JWT auth,
API versioning and Health Checks, all pinned and ready to use.

## Motivation

Building production-ready APIs in- .NET 9+
means installing and wiring the same set of libraries
every time: a logging sink, an OpenAPI provider, a JWT middleware, a versioning library and
health check endpoints. Each with its own version to keep in sync.

**MVFC.Pack.Api** installs all of them in a single reference and pins every version, so you
start with a consistent, battle-tested API baseline from the first line of code.

## Installation

```sh
dotnet add package MVFC.Pack.Api
```

## Quick Start

```csharp
// Program.cs — everything is available after install, no extra packages needed

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

## Included Packages

| Package | Version |
|---|---|
| Serilog.AspNetCore | 10.0.0 |
| Serilog.Sinks.File | 7.0.0 |
| Serilog.Sinks.Console | 6.1.1 |
| Microsoft.AspNetCore.OpenApi | 9.0.2 (net9) / 10.0.14 (net10) / 11.0.0 (net11) |
| Microsoft.AspNetCore.Authentication.JwtBearer | 9.0.2 (net9) / 10.0.14 (net10) / 11.0.0 (net11) |
| Asp.Versioning.Http | 10.2.3 |
| AspNetCore.Scalar | 1.2.0 |
| Microsoft.Extensions.Diagnostics.HealthChecks | 9.0.2 (net9) / 10.0.14 (net10) / 11.0.0 (net11) |
| AspNetCore.HealthChecks.UI.Client | 9.0.0 |

## License

[Apache-2.0](../../LICENSE)
