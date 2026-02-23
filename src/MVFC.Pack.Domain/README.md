# MVFC.Pack.Domain

## Sobre

O **MVFC.Pack.Domain** é um pacote (metapackage) para padronizar e acelerar o desenvolvimento de camadas de domínio em aplicações .NET 10. Ele centraliza as ferramentas essenciais para modelagem de domínio, comunicação entre camadas e validação de dados.

---

## Instalação (NuGet)

Você pode instalar o pacote diretamente via CLI:

```bash
dotnet add package MVFC.Pack.Domain
```

---

## Como Usar

Sendo um metapackage, ao instalá-lo no seu projeto, todas as bibliotecas subjacentes ficam disponíveis para uso imediato em seu código, sem a necessidade de referenciá-las individualmente no `.csproj`. As dependências (`Mediator`, `Refit`, `FluentValidation`, `FluentResults`) estarão prontas para serem importadas usando `using Namespace;`.

---

## Pacotes Inclusos e Versões

Abaixo estão as bibliotecas inclusas neste pacote, bem como suas respectivas versões.

| Pacote | Versão |
| ------ | ------ |
| MediatR | 12.5.0 |
| Refit | 10.0.1 |
| Refit.HttpClientFactory | 10.0.1 |
| FluentResults | 4.0.0 |
| FluentValidation | 12.1.1 |

---

## Motivação

Padronizar a camada de domínio com abstrações do MediatR (CQRS), clientes HTTP declarativos (Refit), tratamento de erros sem exceções (FluentResults) e validação fluente de objetos (FluentValidation). Com este pacote, você já começa com uma base sólida e testável para qualquer microsserviço.

---

## Licença

Este projeto é licenciado sob a licença **Apache License 2.0**. Consulte o arquivo [LICENSE](../../LICENSE) para obter mais detalhes.
