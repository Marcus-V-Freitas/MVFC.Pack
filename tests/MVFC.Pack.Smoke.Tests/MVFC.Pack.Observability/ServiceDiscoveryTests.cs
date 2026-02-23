namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Observability;

public sealed class ServiceDiscoveryTests
{
    [Fact]
    public void ServiceDiscovery_Types_Should_Be_Accessible() =>
        typeof(ServiceEndpointResolver).Should().NotBeNull();
}
