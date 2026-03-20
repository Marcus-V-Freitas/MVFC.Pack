# MVFC.Pack.Testing

> 🇺🇸 [Read in English](README.md) · [← Voltar ao MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.Testing)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Testing)

Metapackage para testes unitários e de integração — xUnit v3, NSubstitute, Bogus, AutoBogus,
FluentAssertions e Testcontainers, com versões fixadas e prontos para uso.

## Motivação

Escrever testes desde o primeiro commit exige o mesmo ecossistema a cada vez: um framework
de testes, uma biblioteca de mocks, um gerador de dados fictícios, uma biblioteca de asserções
com mensagens de falha legíveis, e uma forma de subir infraestrutura real (bancos, brokers)
sem gerenciar arquivos Docker Compose manualmente.

O **MVFC.Pack.Testing** entrega tudo isso, com versões compatíveis fixadas, para que seu
projeto de testes seja produtivo desde o momento da instalação do pacote.

## Instalação

```sh
dotnet add package MVFC.Pack.Testing
```

## Quick Start

```csharp
// 1. Teste unitário com NSubstitute + FluentAssertions
public class OrderServiceTests
{
    private readonly IOrderRepository _repo = Substitute.For<IOrderRepository>();
    private readonly OrderService _sut;

    public OrderServiceTests() => _sut = new OrderService(_repo);

    [Fact]
    public async Task CreateOrder_ShouldReturnId()
    {
        _repo.SaveAsync(Arg.Any<Order>()).Returns(Guid.NewGuid());

        var result = await _sut.CreateAsync(new CreateOrderRequest("Teclado", 1));

        result.Should().NotBeEmpty();
        await _repo.Received(1).SaveAsync(Arg.Any<Order>());
    }
}

// 2. Dados fictícios com Bogus
var faker = new Faker<Order>()
    .RuleFor(o => o.Id,      f => f.Random.Guid())
    .RuleFor(o => o.Product, f => f.Commerce.ProductName())
    .RuleFor(o => o.Total,   f => f.Finance.Amount());

var orders = faker.Generate(10);

// 3. AutoBogus — gera objetos totalmente populados automaticamente
var order = AutoFaker.Generate<Order>();

// 4. Teste de integração com Testcontainers — MongoDB real, sem mocks
public class OrderRepositoryTests : IAsyncLifetime
{
    private readonly MongoDbContainer _mongo = new MongoDbBuilder().Build();

    public Task InitializeAsync() => _mongo.StartAsync();
    public Task DisposeAsync()    => _mongo.DisposeAsync().AsTask();

    [Fact]
    public async Task Insert_ShouldPersistOrder()
    {
        var repo = new OrderRepository(_mongo.GetConnectionString());
        var order = AutoFaker.Generate<Order>();

        await repo.InsertAsync(order);
        var found = await repo.GetByIdAsync(order.Id);

        found.Should().NotBeNull();
        found!.Id.Should().Be(order.Id);
    }
}
```

## Pacotes Inclusos

| Pacote | Versão |
|---|---|
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

## Licença

[Apache-2.0](../../LICENSE)
