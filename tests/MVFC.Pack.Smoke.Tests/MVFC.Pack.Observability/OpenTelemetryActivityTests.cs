using System.Diagnostics;

namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Observability;

public sealed class OpenTelemetryActivityTests
{
    private static readonly ActivitySource TestActivitySource = new("MVFC.Pack.Smoke.Tests");

    [Fact]
    public void ActivitySource_Should_Create_Activity()
    {
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("MVFC.Pack.Smoke.Tests")
            .Build();

        using var activity = TestActivitySource.StartActivity("TestOperation");

        activity.Should().NotBeNull();
        activity!.DisplayName.Should().Be("TestOperation");
        activity.Source.Name.Should().Be("MVFC.Pack.Smoke.Tests");
    }

    [Fact]
    public void Activity_Should_Record_Tags()
    {
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("MVFC.Pack.Smoke.Tests")
            .Build();

        using var activity = TestActivitySource.StartActivity("TaggedOperation");

        activity.Should().NotBeNull();
        activity!.SetTag("order.id", "ORD-001");
        activity.SetTag("order.total", 99.90);
        activity.SetTag("order.items", 3);

        activity.GetTagItem("order.id").Should().Be("ORD-001");
        activity.GetTagItem("order.total").Should().Be(99.90);
        activity.GetTagItem("order.items").Should().Be(3);
    }

    [Fact]
    public void Activity_Should_Record_Events()
    {
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("MVFC.Pack.Smoke.Tests")
            .Build();

        using var activity = TestActivitySource.StartActivity("EventOperation");

        activity.Should().NotBeNull();

        var eventTags = new ActivityTagsCollection
        {
            { "event.detail", "Pedido processado com sucesso" }
        };
        activity!.AddEvent(new ActivityEvent("OrderProcessed", tags: eventTags));

        activity.Events.Should().ContainSingle()
            .Which.Name.Should().Be("OrderProcessed");
    }

    [Fact]
    public void Activity_Should_Support_Nested_Spans()
    {
        using var tracerProvider = Sdk.CreateTracerProviderBuilder()
            .AddSource("MVFC.Pack.Smoke.Tests")
            .Build();

        using var parentActivity = TestActivitySource.StartActivity("ParentOperation");
        parentActivity.Should().NotBeNull();

        using var childActivity = TestActivitySource.StartActivity("ChildOperation");
        childActivity.Should().NotBeNull();
        childActivity!.ParentId.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void OpenTelemetry_Should_Register_Via_DI()
    {
        var services = new ServiceCollection();
        services.AddOpenTelemetry()
            .WithTracing(builder => builder
                .AddSource("MVFC.Pack.Smoke.Tests")
                .AddHttpClientInstrumentation()
                .AddAspNetCoreInstrumentation())
            .WithMetrics(builder => builder
                .AddRuntimeInstrumentation()
                .AddHttpClientInstrumentation()
                .AddAspNetCoreInstrumentation());

        using var provider = services.BuildServiceProvider();
        var tracerProvider = provider.GetService<TracerProvider>();

        tracerProvider.Should().NotBeNull();
    }
}
