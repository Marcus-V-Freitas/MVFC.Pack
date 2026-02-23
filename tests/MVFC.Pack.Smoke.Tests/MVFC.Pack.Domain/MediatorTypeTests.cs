namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Domain;

public sealed class MediatorTypeTests
{
    [Fact]
    public void Mediator_Abstractions_Types_Should_Be_Accessible()
    {
        typeof(IRequest).Should().NotBeNull();
        typeof(IRequest<>).Should().NotBeNull();
        typeof(IRequestHandler<,>).Should().NotBeNull();
        typeof(INotification).Should().NotBeNull();
        typeof(INotificationHandler<>).Should().NotBeNull();
    }
}
