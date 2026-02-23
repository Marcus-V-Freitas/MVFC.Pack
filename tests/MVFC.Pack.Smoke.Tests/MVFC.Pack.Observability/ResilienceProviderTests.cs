namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Observability;

public sealed class ResilienceProviderTests
{
    [Fact]
    public void Resilience_Types_Should_Be_Accessible() =>
        typeof(HttpStandardResilienceOptions).Should().NotBeNull();

    [Fact]
    public void Resilience_Should_Register_Via_DI()
    {
        var services = new ServiceCollection();
        services.AddHttpClient("ObservableClient")
            .AddStandardResilienceHandler();

        using var provider = services.BuildServiceProvider();
        var factory = provider.GetRequiredService<IHttpClientFactory>();
        using var client = factory.CreateClient("ObservableClient");

        client.Should().NotBeNull();
    }
}
