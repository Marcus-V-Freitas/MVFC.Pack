# MVFC.Pack.Cache

> 🇺🇸 [Read in English](README.md) · [← Voltar ao MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.Cache)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Cache)

Metapackage para cache distribuído — Redis via StackExchange e o novo Hybrid Cache do .NET
para estratégias flexíveis L1 (in-memory) / L2 (Redis).

## Motivação

Implementar cache distribuído em aplicações cloud significa configurar o Redis, alinhá-lo
à abstração nativa `IDistributedCache` do .NET, e decidir entre uma abordagem pura de Redis
ou uma estratégia em dois níveis L1/L2. O novo `HybridCache` no .NET 9+
 resolve o problema
de thundering herd e elimina a necessidade de padrões manuais de lock, mas ainda precisa ser
configurado corretamente.

O **MVFC.Pack.Cache** entrega os três pacotes de cache juntos, com versões fixadas, para que
você escolha entre Redis puro ou Hybrid Cache sem dependências adicionais.

## Instalação

```sh
dotnet add package MVFC.Pack.Cache
```

## Quick Start

```csharp
// Opção A — Redis puro
builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration = builder.Configuration.GetConnectionString("Redis"));

// Opção B — Hybrid Cache (L1 in-memory + L2 Redis)
builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration = builder.Configuration.GetConnectionString("Redis"));
builder.Services.AddHybridCache(options =>
{
    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        Expiration           = TimeSpan.FromMinutes(10),
        LocalCacheExpiration = TimeSpan.FromMinutes(2)
    };
});

// Uso com HybridCache — proteção contra thundering herd nativa, sem lock manual
public class ProductService(IHybridCache cache, IProductRepository repo)
{
    public async Task<Product?> GetAsync(Guid id, CancellationToken ct)
        => await cache.GetOrCreateAsync(
            $"product:{id}",
            async token => await repo.GetByIdAsync(id, token),
            cancellationToken: ct);
}
```

## Pacotes Inclusos

| Pacote | Versão |
|---|---|
| StackExchange.Redis | 2.11.3 |
| Microsoft.Extensions.Caching.StackExchangeRedis | 10.0.3 |
| Microsoft.Extensions.Caching.Hybrid | 10.3.0 |

## Licença

[Apache-2.0](../../LICENSE)
