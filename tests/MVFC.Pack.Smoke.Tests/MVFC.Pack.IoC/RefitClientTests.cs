namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.IoC;

public interface ISampleApi
{
    [Get("/users/{id}")]
    public Task<string> GetUserAsync(int id);

    [Post("/users")]
    public Task<string> CreateUserAsync([Body] object user);

    [Put("/users/{id}")]
    public Task UpdateUserAsync(int id, [Body] object user);

    [Delete("/users/{id}")]
    public Task DeleteUserAsync(int id);
}

public sealed class RefitClientTests
{
    [Fact]
    public void Refit_Should_Register_Client_Via_DI()
    {
        var services = new ServiceCollection();
        services.AddRefitClient<ISampleApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.example.com"));

        using var provider = services.BuildServiceProvider();
        var client = provider.GetService<ISampleApi>();

        client.Should().NotBeNull();
    }

    [Fact]
    public void Refit_Should_Register_Client_With_Custom_Settings()
    {
        var services = new ServiceCollection();
        services.AddRefitClient<ISampleApi>(new RefitSettings
        {
            ContentSerializer = new SystemTextJsonContentSerializer()
        })
        .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.example.com"));

        using var provider = services.BuildServiceProvider();
        var client = provider.GetService<ISampleApi>();

        client.Should().NotBeNull();
    }

    [Fact]
    public void Refit_Should_Register_Client_With_Resilience()
    {
        var services = new ServiceCollection();
        services.AddRefitClient<ISampleApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.example.com"))
            .AddStandardResilienceHandler();

        using var provider = services.BuildServiceProvider();
        var client = provider.GetService<ISampleApi>();

        client.Should().NotBeNull();
    }
}
