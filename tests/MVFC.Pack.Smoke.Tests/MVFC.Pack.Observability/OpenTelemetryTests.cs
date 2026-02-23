namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Observability;

public sealed class OpenTelemetryTests
{
    [Fact]
    public void OpenTelemetry_Tracing_Types_Should_Be_Accessible()
    {
        typeof(TracerProvider).Should().NotBeNull();
        typeof(TracerProviderBuilder).Should().NotBeNull();
    }

    [Fact]
    public void OpenTelemetry_Should_Build_TracerProvider()
    {
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddHttpClientInstrumentation()
            .AddAspNetCoreInstrumentation()
            .Build();

        tracerProvider.Should().NotBeNull();
    }

    [Fact]
    public void OpenTelemetry_Metrics_Types_Should_Be_Accessible()
    {
        typeof(MeterProvider).Should().NotBeNull();
        typeof(MeterProviderBuilder).Should().NotBeNull();
    }

    [Fact]
    public void OpenTelemetry_Should_Build_MeterProvider()
    {
        using var meterProvider = Sdk.CreateMeterProviderBuilder()
            .AddRuntimeInstrumentation()
            .AddHttpClientInstrumentation()
            .AddAspNetCoreInstrumentation()
            .Build();

        meterProvider.Should().NotBeNull();
    }

    [Fact]
    public void OpenTelemetry_OtlpExporter_Types_Should_Be_Accessible() =>
        typeof(OtlpExporterOptions).Should().NotBeNull();
}
