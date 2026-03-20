# Contributing to MVFC.Pack

## Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download) or later
- [Docker Desktop](https://www.docker.com/products/docker-desktop/) running locally
- Git

## Running locally

```sh
git clone https://github.com/Marcus-V-Freitas/MVFC.Pack.git
cd MVFC.Pack
dotnet restore MVFC.Pack.slnx
dotnet build MVFC.Pack.slnx --configuration Release
```

## Running tests

The tests require Docker to be running.

```sh
dotnet test tests/MVFC.Pack.Tests/MVFC.Pack.Tests.csproj --configuration Release
```

## Adding a new helper

1. Create a new folder under `src/MVFC.Pack.{ServiceName}/`
2. Follow the structure of an existing helper (e.g. `MVFC.Pack.Helper`)
3. Add the new project to `MVFC.Pack.slnx`
4. Add the package version to `Directory.Packages.props`
5. Add integration tests in `tests/MVFC.Pack.Tests/`
6. Update `README.md` and `README.pt-BR.md` with the new package entry

## Branch naming

- `feat/` — new feature or helper
- `fix/` — bug fix
- `chore/` — dependency update or maintenance
- `docs/` — documentation only
- `test/` — tests only
- `refactor/` — no feature change, no bug fix

Example: `feat/add-pack-helper`

## Commit convention

This project follows [Conventional Commits](https://www.conventionalcommits.org/):

- `feat: add pack helper`
- `fix: fix pack connection timeout`
- `docs: update README badges`
- `chore: bump SqlKata to 2.5.0`
- `test: add pack integration tests`
- `refactor: simplify pack commander setup`

## Pull Request process

1. Fork and create your branch from `main`
2. Make your changes and ensure all tests pass locally
3. Open a PR against `main` and fill in the PR template
4. Wait for the CI to pass
5. A maintainer will review and merge
