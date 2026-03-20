# MVFC.Pack.Analyzers

> 🇺🇸 [Read in English](README.md) · [← Voltar ao MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.Analyzers)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Analyzers)

Metapackage para qualidade de código — SonarAnalyzer, Roslynator e Meziantou.Analyzer
ativam automaticamente no build. Sem configuração necessária.

## Motivação

Manter a qualidade do código consistente em um time exige aplicar as mesmas regras em todo
lugar: sem variáveis não utilizadas, sem comparações de string sem `StringComparison`, sem
cancellation tokens ignorados, sem bloqueio síncrono em contextos assíncronos. Sem uma
baseline de analyzers compartilhada, a IDE de cada desenvolvedor aponta coisas diferentes.

O **MVFC.Pack.Analyzers** instala quatro pacotes de analyzers complementares em uma única
referência. Eles ativam automaticamente no build em todo projeto que referenciar este pacote
— sem `.editorconfig` obrigatório, sem propriedades MSBuild extras, sem nada a configurar.

## Instalação

```sh
dotnet add package MVFC.Pack.Analyzers
```

## Quick Start

Nenhum código necessário. Instale o pacote e os analyzers ativam imediatamente:

```xml
<!-- Recomendado: marcar como asset apenas de desenvolvimento -->
<PackageReference Include="MVFC.Pack.Analyzers" Version="x.x.x">
  <PrivateAssets>all</PrivateAssets>
  <IncludeAssets>runtime; build; native; contentfiles; analyzers</IncludeAssets>
</PackageReference>
```

Exemplos de regras aplicadas automaticamente:

```csharp
// SonarAnalyzer — S2259: desreferência nula
var name = GetName(); // retorna string?
Console.WriteLine(name.Length); // ⚠ aviso: possível referência nula

// Meziantou.Analyzer — MA0006: use StringComparison
if (a == b) { }                              // ⚠ aviso
if (a.Equals(b, StringComparison.Ordinal))  // ✅ correto

// Roslynator — RCS1021: simplifique lambda
list.Where(x => { return x > 0; });  // ⚠ aviso
list.Where(x => x > 0);              // ✅ correto
```

## Pacotes Inclusos

| Pacote | Versão |
|---|---|
| Microsoft.CodeAnalysis.NetAnalyzers | 10.0.103 |
| SonarAnalyzer.CSharp | 10.19.0.132793 |
| Roslynator.Analyzers | 4.15.0 |
| Meziantou.Analyzer | 3.0.15 |

## Licença

[Apache-2.0](../../LICENSE)
