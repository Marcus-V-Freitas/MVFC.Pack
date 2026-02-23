namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Cache;

public sealed class HybridCacheTests
{
    [Fact]
    public void HybridCache_Types_Should_Be_Accessible()
    {
        typeof(HybridCache).Should().NotBeNull();
        typeof(HybridCacheOptions).Should().NotBeNull();
    }
}
