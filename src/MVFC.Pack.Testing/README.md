# MVFC.Pack.Testing

## Sobre

O **MVFC.Pack.Testing** é um pacote (metapackage) focado em unificar as ferramentas essenciais para a escrita de testes automatizados unitários e de integração no ecossistema .NET 10.

---

## Instalação (NuGet)

Você pode instalar o pacote diretamente via CLI no seu projeto de testes:

```bash
dotnet add package MVFC.Pack.Testing
```

---

## Como Usar

Sendo um metapackage, ao instalá-lo no seu projeto de testes, todas as bibliotecas e frameworks necessários ficam imediatamente disponíveis. Ferramentas de testes (`xUnit`, `FluentAssertions`, `NSubstitute`, `Bogus`, `Testcontainers`) estarão prontas para ser importadas usando `using Namespace;` tranquilamente.

---

## Pacotes Inclusos e Versões

Abaixo estão as bibliotecas inclusas neste pacote, bem como suas respectivas versões.

| Pacote | Versão |
| ------ | ------ |
| xunit.v3 | 3.2.2 |
| xunit.v3.extensibility.core | 3.2.2 |
| xunit.runner.visualstudio | 3.1.5 |
| Microsoft.NET.Test.Sdk | 18.0.1 |
| FluentAssertions | 7.0.0 |
| NSubstitute | 5.3.0 |
| Microsoft.AspNetCore.Mvc.Testing | 10.0.3 |
| Bogus | 35.6.5 |
| Testcontainers | 4.10.0 |

---

## Motivação

Agilizar a escrita de testes desde o primeiro momento. Ele já monta um ecossistema com suporte à terceira versão do `xUnit`, o framework líder de mocks `NSubstitute`, dados fictícios realistas com `Bogus`, validações expressivas em inglês com `FluentAssertions` e provisionamento de infraestrutura descartável com `Testcontainers`.

---

## Licença

Este projeto é licenciado sob a licença **Apache License 2.0**. Consulte o arquivo [LICENSE](../../LICENSE) para obter mais detalhes.
