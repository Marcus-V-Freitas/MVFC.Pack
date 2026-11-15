# MVFC.Pack.HttpClient

> 🇺🇸 [Read in English](README.md) · [← Voltar ao MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.HttpClient)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.HttpClient)

Metapackage fornecendo dependências para clientes HTTP tipados com Refit, HttpClientFactory e políticas de resiliência em aplicações .NET 9 e 10.

## O que é e o que não é

- **O que é:** Um metapacote de dependências passivo que consolida e fixa as versões necessárias para declarar clientes REST tipados (Refit + HttpClientFactory) e configurar pipelines de resiliência (`Microsoft.Extensions.Http.Resilience`).
- **O que não é:** Um framework HTTP, biblioteca de helpers ou registro automático de serviços em tempo de execução. Não contém código executável, não cria handlers e não registra serviços no contêiner de DI por conta própria. Toda configuração de clientes e resiliência é decidida explicitamente pela aplicação consumidora.

## Instalação

```sh
dotnet add package MVFC.Pack.HttpClient
```

## Pacotes Inclusos

| Pacote | Versão | Propósito |
|---|---|---|
| `Refit` | 8.0.0 (net9) / 16.4.0 (net10/11) | Cliente REST tipado e declarativo para .NET. |
| `Refit.HttpClientFactory` | 8.0.0 (net9) / 16.4.0 (net10/11) | Integração de clientes Refit com `IHttpClientFactory`. |
| `Microsoft.Extensions.Http` | 9.0.2 (net9) / 10.0.14 (net10) / 11.0.0 (net11) | Abstrações do `IHttpClientFactory` e configuração de clientes HTTP. |
| `Microsoft.Extensions.Http.Resilience` | 9.2.0 (net9) / 10.11.0 (net10) / 11.0.0 (net11) | Pipelines de resiliência padrão (retry, circuit breaker, timeout, rate limiter) baseados em Polly. |

## Quick Start

Na inicialização ou configuração de DI da aplicação:

```csharp
using Microsoft.Extensions.DependencyInjection;
using Refit;

// 1. Defina a interface do cliente tipado
public interface IPingApi
{
    [Get("/ping")]
    Task<string> PingAsync(CancellationToken cancellationToken = default);
}

// 2. Registre via HttpClientFactory e configure a resiliência
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
> **Aviso sobre Resiliência e Idempotência:**  
> O pipeline padrão de resiliência (`AddStandardResilienceHandler`) inclui políticas de retry que podem não ser seguras para métodos HTTP não idempotentes (como `POST` ou operações com efeitos colaterais). Certifique-se de adequar a política de repetição à semântica de cada endpoint para evitar requisições duplicadas indesejadas.

## Compatibilidade

- Frameworks suportados nesta versão: `net9.0;net10.0`.
- A compatibilidade com .NET 9 reflete a linha atual de pacotes do repositório e não constitui compromisso de suporte de longo prazo ao .NET 9.

## Licença

[Apache-2.0](../../LICENSE)
