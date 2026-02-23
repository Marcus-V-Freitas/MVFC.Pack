namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Api;

public sealed class AspVersioningTests
{
    [Fact]
    public void AspVersioning_Types_Should_Be_Accessible()
    {
        typeof(ApiVersion).Should().NotBeNull();
        typeof(ApiVersioningOptions).Should().NotBeNull();
    }
}
