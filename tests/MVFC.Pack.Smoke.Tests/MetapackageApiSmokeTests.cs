namespace MVFC.Pack.Smoke.Tests;

public sealed class MetapackageApiSmokeTests
{
    [Fact]
    public void Refit_Types_Should_Be_Accessible()
    {
        typeof(Refit.ApiException).Should().NotBeNull();
        typeof(Refit.RefitSettings).Should().NotBeNull();
    }

    [Fact]
    public void FluentValidation_Types_Should_Be_Accessible()
    {
        typeof(FluentValidation.IValidator<>).Should().NotBeNull();
        typeof(FluentValidation.AbstractValidator<>).Should().NotBeNull();
        typeof(FluentValidation.Results.ValidationResult).Should().NotBeNull();
    }

    [Fact]
    public void FluentResults_Types_Should_Be_Accessible()
    {
        typeof(FluentResults.Result).Should().NotBeNull();
        typeof(FluentResults.Result<>).Should().NotBeNull();
    }

    [Fact]
    public void Serilog_Types_Should_Be_Accessible()
    {
        typeof(Serilog.ILogger).Should().NotBeNull();
        typeof(Serilog.LoggerConfiguration).Should().NotBeNull();
    }

    [Fact]
    public void Resilience_Types_Should_Be_Accessible()
    {
        typeof(Microsoft.Extensions.Http.Resilience.HttpStandardResilienceOptions).Should().NotBeNull();
    }

    [Fact]
    public void JwtBearer_Types_Should_Be_Accessible()
    {
        typeof(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerOptions).Should().NotBeNull();
        typeof(Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents).Should().NotBeNull();
    }

    [Fact]
    public void OpenApi_Types_Should_Be_Accessible()
    {
        typeof(Microsoft.AspNetCore.OpenApi.OpenApiOptions).Should().NotBeNull();
    }
}