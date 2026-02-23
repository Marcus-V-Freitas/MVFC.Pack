namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Api;

public sealed class JwtBearerTests
{
    [Fact]
    public void JwtBearer_Types_Should_Be_Accessible()
    {
        typeof(JwtBearerOptions).Should().NotBeNull();
        typeof(JwtBearerEvents).Should().NotBeNull();
    }
}
