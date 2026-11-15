# MVFC.Pack.Domain

> 🇧🇷 [Leia em Português](README.pt-br.md) · [← Back to MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.Domain)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Domain)

Metapackage for the Domain / Application layer — CQRS mediator, error handling without exceptions,
and fluent object validation, all pinned.

## Motivation

A solid domain layer in .NET 9+ requires the same set of tools in every project: a CQRS
mediator to decouple commands from handlers, a result type to propagate errors without throwing
exceptions, and a validation library to enforce business rules before any logic runs.

**MVFC.Pack.Domain** pins and ships these core tools in a single reference, so your domain layer
starts consistent and testable from day one. (For typed HTTP clients, see `MVFC.Pack.HttpClient`).

## Installation

```sh
dotnet add package MVFC.Pack.Domain
```

## Quick Start

```csharp
// 1. CQRS with MediatR
public record CreateOrderCommand(Guid CustomerId, decimal Total) : IRequest<Result<Guid>>;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Result<Guid>>
{
    public Task<Result<Guid>> Handle(CreateOrderCommand cmd, CancellationToken ct)
        => Task.FromResult(Result.Ok(Guid.NewGuid()));
}

// 2. Fluent validation
public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.Total).GreaterThan(0).WithMessage("Total must be positive.");
        RuleFor(x => x.CustomerId).NotEmpty();
    }
}

// 3. Result pattern — no exceptions for business errors
var result = await mediator.Send(new CreateOrderCommand(customerId, 99.90m));
if (result.IsFailed)
    return Results.BadRequest(result.Errors.Select(e => e.Message));

return Results.Created($"/orders/{result.Value}", null);
```

## Included Packages

| Package | Version |
|---|---|
| MediatR | 12.5.0 |
| FluentResults | 4.0.0 |
| FluentValidation | 12.2.0 |

## License

[Apache-2.0](../../LICENSE)
