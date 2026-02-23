namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Cache;

public sealed class StackExchangeRedisTests
{
    [Fact]
    public void StackExchangeRedis_Types_Should_Be_Accessible()
    {
        typeof(IConnectionMultiplexer).Should().NotBeNull();
        typeof(IDatabase).Should().NotBeNull();
        typeof(ConfigurationOptions).Should().NotBeNull();
    }
}
