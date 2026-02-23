namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.IoC;

public sealed class ResilienceTests
{
    [Fact]
    public void Resilience_Types_Should_Be_Accessible() =>
        typeof(HttpStandardResilienceOptions).Should().NotBeNull();

    [Fact]
    public void Resilience_Should_Register_Standard_Handler()
    {
        var services = new ServiceCollection();
        services.AddHttpClient("ResilientClient")
            .AddStandardResilienceHandler();

        using var provider = services.BuildServiceProvider();
        var factory = provider.GetRequiredService<IHttpClientFactory>();
        using var client = factory.CreateClient("ResilientClient");

        client.Should().NotBeNull();
    }
}
