namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Api;

public sealed class SerilogTests
{
    [Fact]
    public void Serilog_Types_Should_Be_Accessible()
    {
        typeof(ILogger).Should().NotBeNull();
        typeof(LoggerConfiguration).Should().NotBeNull();
    }

    [Fact]
    public void Serilog_SinksFile_Types_Should_Be_Accessible() =>
        typeof(FileLoggerConfigurationExtensions).Should().NotBeNull();

    [Fact]
    public void Serilog_SinksConsole_Types_Should_Be_Accessible() =>
        typeof(ConsoleLoggerConfigurationExtensions).Should().NotBeNull();

    [Fact]
    public void Serilog_Should_Create_Logger_At_Runtime()
    {
        using var logger = new LoggerConfiguration()
                                .MinimumLevel.Debug()
                                .CreateLogger();

        logger.Should().NotBeNull();
        logger.Information("Smoke test log message");
    }
}
