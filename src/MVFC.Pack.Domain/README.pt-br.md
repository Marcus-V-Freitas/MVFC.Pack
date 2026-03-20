# MVFC.Pack.Domain

> 🇺🇸 [Read in English](README.md) · [← Voltar ao MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.Domain)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Domain)

Metapackage para a camada de Domínio / Aplicação — mediator CQRS, clientes HTTP declarativos,
tratamento de erros sem exceções e validação fluente de objetos, com versões fixadas.

## Motivação

Uma camada de domínio sólida em- .NET 9+
exige o mesmo conjunto de ferramentas em todo projeto:
um mediator CQRS para desacoplar comandos de handlers, um cliente HTTP declarativo para
chamar serviços externos, um tipo de resultado para propagar erros sem lançar exceções, e
uma biblioteca de validação para garantir regras de negócio antes de qualquer lógica rodar.

O **MVFC.Pack.Domain** fixa e entrega os quatro em uma única referência, para que sua camada
de domínio comece consistente e testável desde o primeiro dia.

## Instalação

```sh
dotnet add package MVFC.Pack.Domain
```

## Quick Start

```csharp
// 1. CQRS com MediatR
public record CreateOrderCommand(Guid CustomerId, decimal Total) : IRequest<Result<Guid>>;

public class CreateOrderHandler : IRequestHandler<CreateOrderCommand, Result<Guid>>
{
    public Task<Result<Guid>> Handle(CreateOrderCommand cmd, CancellationToken ct)
        => Task.FromResult(Result.Ok(Guid.NewGuid()));
}

// 2. Cliente HTTP declarativo com Refit
public interface IPaymentApi
{
    [Post("/payments")]
    Task<ApiResponse<PaymentResult>> ChargeAsync(ChargeRequest request, CancellationToken ct);
}

// 3. Validação fluente
public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {
        RuleFor(x => x.Total).GreaterThan(0).WithMessage("Total deve ser positivo.");
        RuleFor(x => x.CustomerId).NotEmpty();
    }
}

// 4. Result pattern — sem exceções para erros de negócio
var result = await mediator.Send(new CreateOrderCommand(customerId, 99.90m));
if (result.IsFailed)
    return Results.BadRequest(result.Errors.Select(e => e.Message));

return Results.Created($"/orders/{result.Value}", null);
```

## Pacotes Inclusos

| Pacote | Versão |
|---|---|
| MediatR | 12.5.0 |
| Refit | 10.0.1 |
| Refit.HttpClientFactory | 10.0.1 |
| FluentResults | 4.0.0 |
| FluentValidation | 12.1.1 |

## Licença

[Apache-2.0](../../LICENSE)
