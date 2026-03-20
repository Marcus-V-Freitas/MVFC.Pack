# Changelog

All notable changes to this project will be documented in this file.

## [[3.0.3]] - 2026-03-20
### Fixed
- Fixed NuGet pack errors NU5103 and NU5128 in `MVFC.Pack.Analyzers`.

## [[3.0.2]] - 2026-03-20
### Fixed
- Fixed metapackage assets propagation to prevent consumer build conflicts.
- Added placeholder files to metapackages to ensure valid NuGet package generation across target frameworks.

## [[3.0.1]] - 2026-03-20
### Fixed
- Fixed metapackage asset propagation in `MVFC.Pack.Testing` to prevent consumer build conflicts.

## [[3.0.0]] - 2026-03-20
### Added
- Native support for **.NET 9** alongside .NET 10 (Multi-targeting).
- Comprehensive package table in root READMEs with internal links and download badges.
- Enhanced `MVFC.Pack.Smoke.Tests` with full xUnit v3/Testcontainers integration.

### Fixed
- Resolved Cake build failures by correcting test project path.
- Fixed missing package references in smoke test project.
- Standardized all README badges to show `.NET 9 | 10` support.

## [[2.0.1]] - 2026-02-23
### Added
- AutoBogus support for automated data generation.

## [[2.0.0]] - 2026-02-23
### Added
- New MetaPackages for standardized development across diferentes domains (Api, Cache, Domain, IoC, Observability, Testing).

## [[1.0.3]] - 2026-02-23
### Fixed
- Duplicated package in project references.

## [[1.0.2]] - 2026-02-23
### Fixed
- `.editorconfig` was being excluded from the build/package.

## [[1.0.1]] - 2026-02-23
### Added
- Intermediate Path configuration for compilation.

## [[1.0.0]] - 2026-02-23
### Added
- Initial project files and repository structure.

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
