namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Cache;

public sealed class DistributedCacheTests
{
    [Fact]
    public void DistributedCache_Types_Should_Be_Accessible()
    {
        typeof(IDistributedCache).Should().NotBeNull();
        typeof(RedisCacheOptions).Should().NotBeNull();
    }
}
