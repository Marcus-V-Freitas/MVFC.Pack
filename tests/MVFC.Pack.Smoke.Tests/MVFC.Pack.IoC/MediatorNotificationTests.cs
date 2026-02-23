namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.IoC;

public sealed record OrderCreatedNotification(Guid OrderId, string ProductName) : INotification;

public sealed class OrderCreatedLogHandler : INotificationHandler<OrderCreatedNotification>
{
    public static ConcurrentBag<Guid> ProcessedOrders { get; } = [];

    public async Task Handle(OrderCreatedNotification notification, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(notification);

        ProcessedOrders.Add(notification.OrderId);
        await Task.CompletedTask.ConfigureAwait(true);
    }
}

public sealed class MediatorNotificationTests
{
    [Fact]
    public async Task Mediator_Should_Publish_Notification_To_Handler()
    {
        OrderCreatedLogHandler.ProcessedOrders.Clear();

        var services = new ServiceCollection();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MediatorNotificationTests).Assembly));

        using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();

        var orderId = Guid.NewGuid();
        await mediator.Publish(new OrderCreatedNotification(orderId, "Teclado Mecânico"), TestContext.Current.CancellationToken);

        OrderCreatedLogHandler.ProcessedOrders.Should().Contain(orderId);
    }

    [Fact]
    public async Task Mediator_Should_Publish_Multiple_Notifications()
    {
        OrderCreatedLogHandler.ProcessedOrders.Clear();

        var services = new ServiceCollection();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(MediatorNotificationTests).Assembly));

        using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();

        var ids = Enumerable.Range(0, 5).Select(_ => Guid.NewGuid()).ToList();

        foreach (var id in ids)
            await mediator.Publish(new OrderCreatedNotification(id, $"Produto-{id}"), TestContext.Current.CancellationToken);

        OrderCreatedLogHandler.ProcessedOrders.Should().Contain(ids);
    }
}
