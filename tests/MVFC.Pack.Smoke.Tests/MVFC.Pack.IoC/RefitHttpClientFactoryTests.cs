namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.IoC;

public sealed class RefitHttpClientFactoryTests
{
    [Fact]
    public void HttpClientFactory_Should_Register_And_Resolve()
    {
        var services = new ServiceCollection();
        services.AddHttpClient();

        using var provider = services.BuildServiceProvider();
        var factory = provider.GetService<IHttpClientFactory>();

        factory.Should().NotBeNull();
    }

    [Fact]
    public void HttpClientFactory_Should_Create_Named_Client()
    {
        var services = new ServiceCollection();
        services.AddHttpClient("TestClient", client => client.BaseAddress = new Uri("https://example.com"));

        using var provider = services.BuildServiceProvider();
        var factory = provider.GetRequiredService<IHttpClientFactory>();
        using var client = factory.CreateClient("TestClient");

        client.Should().NotBeNull();
        client.BaseAddress.Should().Be(new Uri("https://example.com"));
    }
}
