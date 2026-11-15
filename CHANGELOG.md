# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/)
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

---

## [5.0.0] - 2026-11-15

### Added

- **`MVFC.Pack.HttpClient`**: New metapackage providing a dedicated, cohesive composition for typed HTTP clients (`Refit` + `Refit.HttpClientFactory`), `IHttpClientFactory` (`Microsoft.Extensions.Http`), and Polly resilience pipelines (`Microsoft.Extensions.Http.Resilience`).

### Changed (Breaking Changes)

- **`MVFC.Pack.Domain`**: Removed `Refit` and `Refit.HttpClientFactory` dependencies. Domain layer is now strictly focused on CQRS abstractions (`MediatR`), error handling (`FluentResults`), and validation (`FluentValidation`). Consumers requiring declarative HTTP clients must now reference `MVFC.Pack.HttpClient`.
- **`MVFC.Pack.IoC`**: Removed `Microsoft.Extensions.Http` and `Microsoft.Extensions.Http.Resilience` dependencies. IoC is now focused on source-generated mediator registration, compile-time service scanning (`ServiceScan`), and validation DI. Consumers requiring HTTP client registration and resilience must reference `MVFC.Pack.HttpClient`.
- **`MVFC.Pack.Observability`**: Removed `Microsoft.Extensions.Http.Resilience` dependency. Observability is now focused on OpenTelemetry (tracing, metrics, runtime) and Service Discovery.
- Reorganized smoke test suites to align test coverage with each metapackage's dedicated responsibilities.
- Updated central package dependencies and documentation across all metapackages.
- Updated and standardized repository, package, and documentation navigation links across all README files.

---

## [4.0.2] - 2026-11-01

### Changed

- Updated central package versions to their latest stable releases and pinned .NET 9 dependencies.
- Updated Refit smoke test client registrations to `AddRefitGeneratedClient` to align with Refit v16+.

### Fixed

- Fixed `.editorconfig` copy path in `MVFC.Pack.Analyzers.targets`.

---

## [4.0.1] - 2026-06-26

### Changed

- Updated metapackage versions to their latest stable releases

## [4.0.0] - 2026-04-07

### Added

- Automated versioning with **MinVer**.
- Rollback mechanism in the CI pipeline to cleanup tags and releases on failure.
- Codecov and test runsettings configurations to exclude `tests` and `playground` coverage.

### Changed

- Centralized `ImplicitUsings`, `Nullable`, and `LangVersion` within `Directory.Build.props`.
- Modernized icons across all metapackages.
- Refactored CI/CD workflow to support `MinVer` packaging.
- Updated central package versions to their latest stable releases.

### Removed

- `<Version>` overrides in `csproj` files and manual version extraction logic in CI/CD.

---

## [3.0.3] - 2026-03-20

### Fixed

- Fixed NuGet pack errors NU5103 and NU5128 in `MVFC.Pack.Analyzers`.

---

## [3.0.2] - 2026-03-20

### Fixed

- Fixed metapackage assets propagation to prevent consumer build conflicts.
- Added placeholder files to metapackages to ensure valid NuGet package generation across target frameworks.

---

## [3.0.1] - 2026-03-20

### Fixed

- Fixed metapackage asset propagation in `MVFC.Pack.Testing` to prevent consumer build conflicts.

---

## [3.0.0] - 2026-03-20

### Added

- Native support for **.NET 9** alongside .NET 10 (Multi-targeting).
- Comprehensive package table in root READMEs with internal links and download badges.
- Enhanced `MVFC.Pack.Smoke.Tests` with full xUnit v3/Testcontainers integration.

### Fixed

- Resolved Cake build failures by correcting test project path.
- Fixed missing package references in smoke test project.
- Standardized all README badges to show `.NET 9 | 10` support.

---

## [2.0.1] - 2026-02-23

### Added

- AutoBogus support for automated data generation.

---

## [2.0.0] - 2026-02-23

### Added

- New MetaPackages for standardized development across diferentes domains (Api, Cache, Domain, IoC, Observability, Testing).

---

## [1.0.3] - 2026-02-23

### Fixed

- Duplicated package in project references.

---

## [1.0.2] - 2026-02-23

### Fixed

- `.editorconfig` was being excluded from the build/package.

---

## [1.0.1] - 2026-02-23

### Added

- Intermediate Path configuration for compilation.

---

## [1.0.0] - 2026-02-23

### Added

- Initial project files and repository structure.

---

[4.0.2]: https://github.com/Marcus-V-Freitas/MVFC.Pack/compare/v4.0.1...v4.0.2
[4.0.1]: https://github.com/Marcus-V-Freitas/MVFC.Pack/compare/v4.0.0...v4.0.1
[4.0.0]: https://github.com/Marcus-V-Freitas/MVFC.Pack/compare/v3.0.3...v4.0.0
[3.0.3]: https://github.com/Marcus-V-Freitas/MVFC.Pack/compare/v3.0.2...v3.0.3
[3.0.2]: https://github.com/Marcus-V-Freitas/MVFC.Pack/compare/v3.0.1...v3.0.2
[3.0.1]: https://github.com/Marcus-V-Freitas/MVFC.Pack/compare/v3.0.0...v3.0.1
[3.0.0]: https://github.com/Marcus-V-Freitas/MVFC.Pack/compare/v2.0.1...v3.0.0
[2.0.1]: https://github.com/Marcus-V-Freitas/MVFC.Pack/compare/v2.0.0...v2.0.1
[2.0.0]: https://github.com/Marcus-V-Freitas/MVFC.Pack/compare/v1.0.3...v2.0.0
[1.0.3]: https://github.com/Marcus-V-Freitas/MVFC.Pack/compare/v1.0.2...v1.0.3
[1.0.2]: https://github.com/Marcus-V-Freitas/MVFC.Pack/compare/v1.0.1...v1.0.2
[1.0.1]: https://github.com/Marcus-V-Freitas/MVFC.Pack/compare/v1.0.0...v1.0.1
[1.0.0]: https://github.com/Marcus-V-Freitas/MVFC.Pack/releases/tag/v1.0.0
