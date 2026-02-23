namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Domain;

public sealed class RefitTests
{
    [Fact]
    public void Refit_Types_Should_Be_Accessible()
    {
        typeof(ApiException).Should().NotBeNull();
        typeof(RefitSettings).Should().NotBeNull();
    }

    [Fact]
    public void Refit_Attributes_Should_Be_Usable()
    {
        typeof(GetAttribute).Should().NotBeNull();
        typeof(PostAttribute).Should().NotBeNull();
        typeof(PutAttribute).Should().NotBeNull();
        typeof(DeleteAttribute).Should().NotBeNull();
        typeof(HeaderAttribute).Should().NotBeNull();
    }
}
