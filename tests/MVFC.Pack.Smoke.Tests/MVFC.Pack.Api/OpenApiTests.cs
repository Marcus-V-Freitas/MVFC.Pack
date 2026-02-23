namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Api;

public sealed class OpenApiTests
{
    [Fact]
    public void OpenApi_Types_Should_Be_Accessible() =>
        typeof(OpenApiOptions).Should().NotBeNull();
}
