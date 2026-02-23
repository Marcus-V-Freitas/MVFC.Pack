namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Testing;

public sealed class MvcTestingTests
{
    [Fact]
    public void MvcTesting_Types_Should_Be_Accessible() =>
        typeof(WebApplicationFactory<>).Should().NotBeNull();
}
