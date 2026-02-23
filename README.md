# MVFC.Pack

## Sobre

O **MVFC.Pack** é uma coleção de pacotes (metapackages) pensada para padronizar e acelerar o desenvolvimento de aplicações no ecossistema .NET 10. Ao invés de instalar as mesmas bibliotecas repetidamente em cada novo microsserviço ou projeto, você pode simplesmente referenciar os pacotes do MVFC.Pack de acordo com a sua necessidade. Eles garantem que as versões das dependências estejam sempre alinhadas e adotam as melhores ferramentas do mercado por padrão.

---

## Instalação (NuGet)

Você pode instalar os pacotes diretamente via CLI, utilizando o mesmo nome do projeto alvo. Escolha os pacotes que fazem sentido para o seu contexto:

```bash
# Para projetos de API (Serilog, OpenApi, JWT, HealthChecks...)
dotnet add package MVFC.Pack.Api

# Para camada de Domínio (Mediator, Refit, FluentValidation, FluentResults)
dotnet add package MVFC.Pack.Domain

# Para configuração de IoC (Mediator SourceGenerator, ServiceScan, DI)
dotnet add package MVFC.Pack.IoC

# Para Observabilidade (OpenTelemetry, Service Discovery, Resiliência)
dotnet add package MVFC.Pack.Observability

# Para configuração de Cache (Redis e Hybrid Cache)
dotnet add package MVFC.Pack.Cache

# Para padronização e análise de código (Linting/Analyzers)
dotnet add package MVFC.Pack.Analyzers

# Para projetos de Testes (Unitários/Integração)
dotnet add package MVFC.Pack.Testing
```

---

## Como Usar
Como a maioria destes pacotes atua como *Metapackages* (agrupadores de dependências), o simples fato de você instalá-los no seu projeto já torna todas as bibliotecas e ferramentas subjacentes disponíveis para uso imediato em seu código, sem necessidade de referenciá-las individualmente no `.csproj`.

- **Analisadores:** Ao instalar o pacote `MVFC.Pack.Analyzers`, os rulesets e analisadores (Sonar, Roslynator, etc.) já entram em ação automaticamente no seu editor, apontando melhorias no código durante o desenvolvimento.
- **Bibliotecas:** As dependências do pacote de testes (`xUnit`, `FluentAssertions`, `Testcontainers`), APIs (`Serilog`, `OpenApi`, `JWT`), Domínio (`Mediator`, `Refit`, `FluentResults`) ou Cache (`Redis`) estarão prontas para ser importadas usando `using Namespace;` tranquilamente.

---

## Pacotes Inclusos e Versões

Abaixo estão as bibliotecas inclusas em cada pacote, bem como suas respectivas versões fixadas no repositório.

---

### MVFC.Pack.Api
| Pacote | Versão |
| ------ | ------ |
| Serilog.AspNetCore | 10.0.0 |
| Serilog.Sinks.File | 7.0.0 |
| Serilog.Sinks.Console | 6.1.1 |
| Microsoft.AspNetCore.OpenApi | 10.0.3 |
| Microsoft.AspNetCore.Authentication.JwtBearer | 10.0.3 |
| Asp.Versioning.Http | 8.1.1 |
| AspNetCore.Scalar | 1.2.0 |
| Microsoft.Extensions.Diagnostics.HealthChecks | 10.0.3 |
| AspNetCore.HealthChecks.UI.Client | 9.0.0 |

### MVFC.Pack.Domain
| Pacote | Versão |
| ------ | ------ |
| MediatR | 12.5.0 |
| Refit | 10.0.1 |
| Refit.HttpClientFactory | 10.0.1 |
| FluentResults | 4.0.0 |
| FluentValidation | 12.1.1 |

### MVFC.Pack.IoC
| Pacote | Versão |
| ------ | ------ |
| MediatR | 12.5.0 |
| ServiceScan.SourceGenerator | 2.4.1 |
| FluentValidation.DependencyInjectionExtensions | 12.1.1 |
| Microsoft.Extensions.Http | 10.0.3 |
| Microsoft.Extensions.Http.Resilience | 10.3.0 |

### MVFC.Pack.Observability
| Pacote | Versão |
| ------ | ------ |
| Microsoft.Extensions.Http.Resilience | 10.3.0 |
| Microsoft.Extensions.ServiceDiscovery | 10.3.0 |
| OpenTelemetry.Exporter.OpenTelemetryProtocol | 1.15.0 |
| OpenTelemetry.Extensions.Hosting | 1.15.0 |
| OpenTelemetry.Instrumentation.AspNetCore | 1.15.0 |
| OpenTelemetry.Instrumentation.Http | 1.15.0 |
| OpenTelemetry.Instrumentation.Runtime | 1.15.0 |

### MVFC.Pack.Cache
| Pacote | Versão |
| ------ | ------ |
| StackExchange.Redis | 2.11.3 |
| Microsoft.Extensions.Caching.StackExchangeRedis | 10.0.3 |
| Microsoft.Extensions.Caching.Hybrid | 10.3.0 |

### MVFC.Pack.Analyzers
| Pacote | Versão |
| ------ | ------ |
| Microsoft.CodeAnalysis.NetAnalyzers | 10.0.103 |
| SonarAnalyzer.CSharp | 10.19.0.132793 |
| Roslynator.Analyzers | 4.15.0 |
| Meziantou.Analyzer | 3.0.15 |

### MVFC.Pack.Testing
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
| AutoBogus | 2.13.1 |
| Testcontainers | 4.10.0 |

---

## Motivação de Cada Pacote

- **`MVFC.Pack.Api`**: 
  - Centralizar toda a base para a criação de APIs ricas e robustas. Este pacote já traz ferramentas para logs estruturados (Serilog), documentação de rotas (OpenApi/Scalar), versionamento de API (Asp.Versioning), segurança com JWT e Health Checks padronizados.
  
- **`MVFC.Pack.Domain`**: 
  - Padronizar a camada de domínio com abstrações do Mediator (CQRS), clientes HTTP declarativos (Refit), tratamento de erros sem exceções (FluentResults) e validação fluente de objetos (FluentValidation).

- **`MVFC.Pack.IoC`**: 
  - Centralizar a configuração de IoC com o Mediator (CQRS via Source Generator para máxima performance), registro automático de serviços (ServiceScan), integração do FluentValidation com DI e criação de clientes HTTP resilientes (HttpClientFactory + Polly).

- **`MVFC.Pack.Observability`**: 
  - Entregar observabilidade completa com tracing distribuído, métricas e instrumentação automática (OpenTelemetry), resolução dinâmica de serviços (Service Discovery) e resiliência para chamadas HTTP. Essencial para microsserviços e arquiteturas cloud-native.

- **`MVFC.Pack.Cache`**: 
  - Entregar facilidade para implementação de cache distribuído em arquiteturas em nuvem (Redis), alinhado com as abstrações nativas do .NET e o uso flexível do novo Hybrid Cache.

- **`MVFC.Pack.Analyzers`**: 
  - Garantir qualidade, legibilidade e segurança no código C#. Esse grupo de analisadores força as melhores práticas durante as builds ou na própria IDE, evitando "code smells" tradicionais identificados pela comunidade (SonarAnalyzer, Roslynator e NetAnalyzers). Em suma, ele eleva a qualidade do código com inspeção contínua.

- **`MVFC.Pack.Testing`**: 
  - Agilizar a escrita de testes desde o primeiro momento. Ele já monta um ecossistema com suporte à terceira versão do `xUnit`, o framework líder de mocks `NSubstitute`, dados fictícios realistas com `Bogus` e `AutoBogus` (AutoFaker), validações expressivas em inglês com `FluentAssertions` e provisionamento de infraestrutura descartável com `Testcontainers`.

---

## Licença
Este projeto é licenciado sob a licença **Apache License 2.0**. Consulte o arquivo [LICENSE](./LICENSE) para obter mais detalhes.
