namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.HttpClient;

public interface IHttpClientSmokeApi
{
    [Get("/health")]
    public Task<string> CheckHealthAsync();
}

public sealed class HttpClientSmokeTests
{
    [Fact]
    public void HttpClient_Types_Should_Be_Accessible()
    {
        typeof(IHttpClientFactory).Should().NotBeNull();
        typeof(HttpStandardResilienceOptions).Should().NotBeNull();
        typeof(IHttpClientSmokeApi).Should().NotBeNull();
    }

    [Fact]
    public void HttpClient_Should_Register_Refit_Client_With_Resilience()
    {
        var services = new ServiceCollection();
        services.AddRefitGeneratedClient<IHttpClientSmokeApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.example.com"))
            .AddStandardResilienceHandler();

        using var provider = services.BuildServiceProvider();
        var client = provider.GetService<IHttpClientSmokeApi>();

        client.Should().NotBeNull();
    }
}
