namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Api;

public sealed class HealthChecksTests
{
    [Fact]
    public void HealthChecks_Types_Should_Be_Accessible()
    {
        typeof(HealthCheckService).Should().NotBeNull();
        typeof(HealthCheckResult).Should().NotBeNull();
    }

    [Fact]
    public void HealthChecksUI_Types_Should_Be_Accessible() =>
        typeof(UIResponseWriter).Should().NotBeNull();
}
