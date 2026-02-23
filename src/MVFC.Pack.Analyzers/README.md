# MVFC.Pack.Analyzers

## Sobre

O **MVFC.Pack.Analyzers** é um pacote focado em garantir a qualidade, legibilidade e segurança no código C# de suas aplicações .NET 10 através de análise estática contínua.

---

## Instalação (NuGet)

Você pode instalar o pacote diretamente via CLI:

```bash
dotnet add package MVFC.Pack.Analyzers
```

---

## Como Usar

Ao instalar o pacote `MVFC.Pack.Analyzers`, os rulesets e analisadores (Sonar, Roslynator, etc.) já entram em ação automaticamente no seu editor e no processo de build, apontando melhorias no código durante o desenvolvimento.

---

## Pacotes Inclusos e Versões

Abaixo estão as bibliotecas inclusas neste pacote, bem como suas respectivas versões.

| Pacote | Versão |
| ------ | ------ |
| Microsoft.CodeAnalysis.NetAnalyzers | 10.0.103 |
| SonarAnalyzer.CSharp | 10.19.0.132793 |
| Roslynator.Analyzers | 4.15.0 |
| Meziantou.Analyzer | 3.0.15 |

---

## Motivação

Garantir qualidade, legibilidade e segurança no código C#. Esse grupo de analisadores força as melhores práticas durante as builds ou na própria IDE, evitando "code smells" tradicionais identificados pela comunidade (SonarAnalyzer, Roslynator e NetAnalyzers). Em suma, ele eleva a qualidade do código com inspeção contínua.

---

## Licença

Este projeto é licenciado sob a licença **Apache License 2.0**. Consulte o arquivo [LICENSE](../../LICENSE) para obter mais detalhes.
