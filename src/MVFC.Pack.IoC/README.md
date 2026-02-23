# MVFC.Pack.IoC

## Sobre

O **MVFC.Pack.IoC** é um pacote (metapackage) para padronizar e acelerar a configuração de inversão de controle (IoC) em aplicações .NET 10. Ele centraliza as ferramentas essenciais para registro de serviços, mediação de comandos/queries e configuração de clientes HTTP.

---

## Instalação (NuGet)

Você pode instalar o pacote diretamente via CLI:

```bash
dotnet add package MVFC.Pack.IoC
```

---

## Como Usar

Sendo um metapackage, ao instalá-lo no seu projeto, todas as bibliotecas subjacentes ficam disponíveis para uso imediato em seu código, sem a necessidade de referenciá-las individualmente no `.csproj`. O Source Generator do Mediator e o ServiceScan serão ativados automaticamente no projeto consumidor.

---

## Pacotes Inclusos e Versões

Abaixo estão as bibliotecas inclusas neste pacote, bem como suas respectivas versões.

| Pacote | Versão |
| ------ | ------ |
| MediatR | 12.5.0 |
| ServiceScan.SourceGenerator | 2.4.1 |
| FluentValidation.DependencyInjectionExtensions | 12.1.1 |
| Microsoft.Extensions.Http | 10.0.3 |
| Microsoft.Extensions.Http.Resilience | 10.3.0 |

---

## Motivação

Centralizar a configuração de IoC com o MediatR (CQRS), registro automático de serviços (ServiceScan), integração do FluentValidation com DI e criação de clientes HTTP resilientes (HttpClientFactory + Polly).

---

## Licença

Este projeto é licenciado sob a licença **Apache License 2.0**. Consulte o arquivo [LICENSE](../../LICENSE) para obter mais detalhes.
