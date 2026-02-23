namespace MVFC.Pack.Smoke.Tests;

public sealed class MetapackageCacheSmokeTests
{
    [Fact]
    public void StackExchangeRedis_Types_Should_Be_Accessible()
    {
        typeof(StackExchange.Redis.IConnectionMultiplexer).Should().NotBeNull();
        typeof(StackExchange.Redis.IDatabase).Should().NotBeNull();
        typeof(StackExchange.Redis.ConfigurationOptions).Should().NotBeNull();
    }

    [Fact]
    public void DistributedCache_Types_Should_Be_Accessible()
    {
        typeof(Microsoft.Extensions.Caching.Distributed.IDistributedCache).Should().NotBeNull();
        typeof(Microsoft.Extensions.Caching.StackExchangeRedis.RedisCacheOptions).Should().NotBeNull();
    }

    [Fact]
    public void HybridCache_Types_Should_Be_Accessible()
    {
        typeof(Microsoft.Extensions.Caching.Hybrid.HybridCache).Should().NotBeNull();
        typeof(Microsoft.Extensions.Caching.Hybrid.HybridCacheOptions).Should().NotBeNull();
    }
}