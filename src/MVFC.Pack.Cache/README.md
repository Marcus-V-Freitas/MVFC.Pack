# MVFC.Pack.Cache

> 🇧🇷 [Leia em Português](README.pt-br.md) · [← Back to MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.Cache)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Cache)

Metapackage for distributed cache — Redis via StackExchange and the new .NET Hybrid Cache
for flexible L1 (in-memory) / L2 (Redis) strategies.

## Motivation

Implementing distributed cache in cloud applications means wiring Redis, aligning it with
.NET's native `IDistributedCache` abstraction, and deciding between a pure Redis approach
or a two-tier L1/L2 strategy. The new `HybridCache` in- .NET 9+
 solves the stampede problem
and removes the need for custom locking patterns, but it still needs to be properly wired up.

**MVFC.Pack.Cache** ships all three cache packages together, pinned, so you can choose
between pure Redis or Hybrid Cache without any additional dependencies.

## Installation

```sh
dotnet add package MVFC.Pack.Cache
```

## Quick Start

```csharp
// Option A — pure Redis
builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration = builder.Configuration.GetConnectionString("Redis"));

// Option B — Hybrid Cache (L1 in-memory + L2 Redis)
builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration = builder.Configuration.GetConnectionString("Redis"));
builder.Services.AddHybridCache(options =>
{
    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        Expiration         = TimeSpan.FromMinutes(10),
        LocalCacheExpiration = TimeSpan.FromMinutes(2)
    };
});

// Usage with HybridCache — built-in stampede protection, no manual locking needed
public class ProductService(IHybridCache cache, IProductRepository repo)
{
    public async Task<Product?> GetAsync(Guid id, CancellationToken ct)
        => await cache.GetOrCreateAsync(
            $"product:{id}",
            async token => await repo.GetByIdAsync(id, token),
            cancellationToken: ct);
}
```

## Included Packages

| Package | Version |
|---|---|
| StackExchange.Redis | 3.4.35 |
| Microsoft.Extensions.Caching.StackExchangeRedis | 9.0.2 (net9) / 10.0.14 (net10) / 11.0.0 (net11) |
| Microsoft.Extensions.Caching.Hybrid | 10.11.0 (net9/10) / 11.0.0 (net11) |

## License

[Apache-2.0](../../LICENSE)
