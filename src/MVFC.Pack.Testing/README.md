# MVFC.Pack.Testing

> 🇧🇷 [Leia em Português](README.pt-br.md) · [← Back to MVFC.Pack](../../README.md)

[![License](https://img.shields.io/badge/license-Apache--2.0-blue)](../../LICENSE)
![Platform](https://img.shields.io/badge/.NET-9%20%7C%2010-blue)
![NuGet Version](https://img.shields.io/nuget/v/MVFC.Pack.Testing)
![NuGet Downloads](https://img.shields.io/nuget/dt/MVFC.Pack.Testing)

Metapackage for unit and integration testing — xUnit v3, NSubstitute, Bogus, AutoBogus,
FluentAssertions and Testcontainers, all pinned and ready.

## Motivation

Writing tests from the first commit requires the same ecosystem every time: a test framework,
a mocking library, a fake-data generator, an assertion library with readable failure messages,
and a way to spin up real infrastructure (databases, brokers) without managing Docker Compose
files manually.

**MVFC.Pack.Testing** ships all of them, pinned to compatible versions, so your test project
is productive from the moment the package is installed.

## Installation

```sh
dotnet add package MVFC.Pack.Testing
```

## Quick Start

```csharp
// 1. Unit test with NSubstitute + FluentAssertions
public class OrderServiceTests
{
    private readonly IOrderRepository _repo = Substitute.For<IOrderRepository>();
    private readonly OrderService _sut;

    public OrderServiceTests() => _sut = new OrderService(_repo);

    [Fact]
    public async Task CreateOrder_ShouldReturnId()
    {
        _repo.SaveAsync(Arg.Any<Order>()).Returns(Guid.NewGuid());

        var result = await _sut.CreateAsync(new CreateOrderRequest("Keyboard", 1));

        result.Should().NotBeEmpty();
        await _repo.Received(1).SaveAsync(Arg.Any<Order>());
    }
}

// 2. Fake data with Bogus
var faker = new Faker<Order>()
    .RuleFor(o => o.Id,      f => f.Random.Guid())
    .RuleFor(o => o.Product, f => f.Commerce.ProductName())
    .RuleFor(o => o.Total,   f => f.Finance.Amount());

var orders = faker.Generate(10);

// 3. AutoBogus — generate fully populated objects automatically
var order = AutoFaker.Generate<Order>();

// 4. Integration test with Testcontainers — real MongoDB, no mocks
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

## Included Packages

| Package | Version |
|---|---|
| xunit.v3 | 4.0.3 |
| xunit.v3.extensibility.core | 4.0.3 |
| xunit.runner.visualstudio | 4.0.1 |
| Microsoft.NET.Test.Sdk | 18.12.0 |
| FluentAssertions | 7.0.0 |
| NSubstitute | 6.2.0 |
| Microsoft.AspNetCore.Mvc.Testing | 9.0.2 (net9) / 10.0.14 (net10) / 11.0.0 (net11) |
| Bogus | 35.6.5 |
| AutoBogus | 2.13.1 |
| Testcontainers | 4.16.0 |

## License

[Apache-2.0](../../LICENSE)
