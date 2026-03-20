# MVFC.Pack.Analyzers

> 🇧🇷 [Leia em Português](README.pt-br.md) · [← Back to MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.Analyzers)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Analyzers)

Metapackage for code quality — SonarAnalyzer, Roslynator and Meziantou.Analyzer activate
automatically at build time. No configuration required.

## Motivation

Keeping code quality consistent across a team requires enforcing the same rules everywhere:
no unused variables, no string comparisons without `StringComparison`, no unhandled
cancellation tokens, no synchronous blocking in async contexts. Without a shared analyzer
baseline, every developer's IDE flags different things.

**MVFC.Pack.Analyzers** installs four complementary analyzer packages in a single reference.
They activate automatically at build time in every project that references this package —
no `.editorconfig` required, no extra MSBuild properties, nothing to configure.

## Installation

```sh
dotnet add package MVFC.Pack.Analyzers
```

## Quick Start

No code required. Install the package and analyzers activate immediately:

```xml
<!-- Recommended: mark as development-only asset -->
<PackageReference Include="MVFC.Pack.Analyzers" Version="x.x.x">
  <PrivateAssets>all</PrivateAssets>
  <IncludeAssets>runtime; build; native; contentfiles; analyzers</IncludeAssets>
</PackageReference>
```

Examples of rules enforced automatically:

```csharp
// SonarAnalyzer — S2259: null dereference
var name = GetName(); // returns string?
Console.WriteLine(name.Length); // ⚠ warning: possible null reference

// Meziantou.Analyzer — MA0006: use StringComparison
if (a == b) { }                              // ⚠ warning
if (a.Equals(b, StringComparison.Ordinal))  // ✅ correct

// Roslynator — RCS1021: simplify lambda
list.Where(x => { return x > 0; });  // ⚠ warning
list.Where(x => x > 0);              // ✅ correct
```

## Included Packages

| Package | Version |
|---|---|
| Microsoft.CodeAnalysis.NetAnalyzers | 10.0.103 |
| SonarAnalyzer.CSharp | 10.19.0.132793 |
| Roslynator.Analyzers | 4.15.0 |
| Meziantou.Analyzer | 3.0.15 |

## License

[Apache-2.0](../../LICENSE)
