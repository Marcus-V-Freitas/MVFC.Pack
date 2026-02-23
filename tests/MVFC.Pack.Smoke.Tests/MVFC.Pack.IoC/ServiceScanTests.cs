namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.IoC;

public interface ISampleNotifier
{
    public string Notify(string message);
}

public sealed class SampleNotifier : ISampleNotifier
{
    public string Notify(string message) => $"Notificado: {message}";
}

public sealed class AlternativeNotifier : ISampleNotifier
{
    public string Notify(string message) => $"Alternativo: {message}";
}

public static partial class TestServiceRegistrations
{
    [GenerateServiceRegistrations(AssignableTo = typeof(ISampleNotifier), Lifetime = ServiceLifetime.Scoped)]
    public static partial IServiceCollection AddTestNotifiers(this IServiceCollection services);
}

public sealed class ServiceScanTests
{
    [Fact]
    public void ServiceScan_Should_Register_Scoped_Services()
    {
        var services = new ServiceCollection();
        services.AddTestNotifiers();

        using var provider = services.BuildServiceProvider();
        var notifier = provider.GetService<ISampleNotifier>();

        notifier.Should().NotBeNull();
    }

    [Fact]
    public void ServiceScan_Should_Register_Multiple_Implementations()
    {
        var services = new ServiceCollection();
        services.AddTestNotifiers();

        using var provider = services.BuildServiceProvider();
        var notifiers = provider.GetServices<ISampleNotifier>().ToList();

        notifiers.Should().HaveCount(2);
        notifiers.Select(n => n.GetType()).Should().Contain([typeof(SampleNotifier), typeof(AlternativeNotifier)]);
    }
}
