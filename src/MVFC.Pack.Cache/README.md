# MVFC.Pack.Cache

## Sobre

O **MVFC.Pack.Cache** é um pacote (metapackage) projetado para simplificar e padronizar a implementação de cache distribuído em aplicações .NET 10.

---

## Instalação (NuGet)

Você pode instalar o pacote diretamente via CLI:

```bash
dotnet add package MVFC.Pack.Cache
```

---

## Como Usar

Sendo um metapackage, ao instalá-lo no seu projeto, todas as bibliotecas estruturais para cache ficam disponíveis para uso imediato em seu código, sem necessidade de referenciá-las individualmente no `.csproj`. As dependências do Redis e do Hybrid Cache estarão prontas para ser configuradas via injeção de dependência.

---

## Pacotes Inclusos e Versões

Abaixo estão as bibliotecas inclusas neste pacote, bem como suas respectivas versões.

| Pacote | Versão |
| ------ | ------ |
| StackExchange.Redis | 2.11.3 |
| Microsoft.Extensions.Caching.StackExchangeRedis | 10.0.3 |
| Microsoft.Extensions.Caching.Hybrid | 10.3.0 |

---

## Motivação

Entregar facilidade para implementação de cache distribuído em arquiteturas em nuvem (Redis), alinhado com as abstrações nativas do .NET e o uso flexível do novo Hybrid Cache.

---

## Licença

Este projeto é licenciado sob a licença **Apache License 2.0**. Consulte o arquivo [LICENSE](../../LICENSE) para obter mais detalhes.
