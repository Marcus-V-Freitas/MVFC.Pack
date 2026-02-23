namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Testing;

public sealed class TestcontainersTests
{
    [Fact]
    public void Testcontainers_Types_Should_Be_Accessible()
    {
        typeof(IContainer).Should().NotBeNull();
        typeof(IContainerConfiguration).Should().NotBeNull();
    }
}
