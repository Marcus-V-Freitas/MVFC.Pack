namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.IoC;

public sealed record CreateOrderCommand(string ProductName, int Quantity) : IRequest<Result<Guid>>;

public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        if (string.IsNullOrWhiteSpace(command.ProductName))
            return await Task.FromResult(Result.Fail<Guid>("Nome do produto é obrigatório")).ConfigureAwait(true);

        if (command.Quantity <= 0)
            return await Task.FromResult(Result.Fail<Guid>("Quantidade deve ser maior que zero")).ConfigureAwait(true);

        var orderId = Guid.NewGuid();
        return await Task.FromResult(Result.Ok(orderId)).ConfigureAwait(true);
    }
}

public sealed class MediatorTests
{
    [Fact]
    public void Mediator_Should_Register_And_Resolve()
    {
        var services = new ServiceCollection();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MediatorTests).Assembly));

        using var provider = services.BuildServiceProvider();
        var mediator = provider.GetService<IMediator>();

        mediator.Should().NotBeNull();
    }

    [Fact]
    public async Task Handler_Should_Return_Success_For_Valid_Command()
    {
        var handler = new CreateOrderCommandHandler();

        var result = await handler.Handle(
            new CreateOrderCommand("Notebook", 2),
            TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Handler_Should_Fail_For_Empty_ProductName()
    {
        var handler = new CreateOrderCommandHandler();

        var result = await handler.Handle(
            new CreateOrderCommand("", 2),
            TestContext.Current.CancellationToken);

        result.IsFailed.Should().BeTrue();
        result.Errors.Should().ContainSingle()
            .Which.Message.Should().Contain("Nome do produto");
    }

    [Fact]
    public async Task Handler_Should_Fail_For_Invalid_Quantity()
    {
        var handler = new CreateOrderCommandHandler();

        var result = await handler.Handle(
            new CreateOrderCommand("Notebook", -1),
            TestContext.Current.CancellationToken);

        result.IsFailed.Should().BeTrue();
        result.Errors.Should().ContainSingle()
            .Which.Message.Should().Contain("Quantidade");
    }
}
