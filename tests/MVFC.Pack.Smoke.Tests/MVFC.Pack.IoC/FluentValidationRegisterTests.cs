namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.IoC;

public sealed class FluentValidationRegisterTests
{
    [Fact]
    public void FluentValidation_Should_Register_Validators_From_Assembly()
    {
        var services = new ServiceCollection();
        services.AddValidatorsFromAssemblyContaining<SampleOrderValidator>();

        using var provider = services.BuildServiceProvider();
        var validator = provider.GetService<IValidator<SampleOrder>>();

        validator.Should().NotBeNull();
    }

    [Fact]
    public void FluentValidation_DI_Resolved_Validator_Should_Work()
    {
        var services = new ServiceCollection();
        services.AddValidatorsFromAssemblyContaining<SampleOrderValidator>();

        using var provider = services.BuildServiceProvider();
        var validator = provider.GetRequiredService<IValidator<SampleOrder>>();

        var validResult = validator.Validate(new SampleOrder("ORD-001", 10.0m));
        validResult.IsValid.Should().BeTrue();

        var invalidResult = validator.Validate(new SampleOrder("", -5m));
        invalidResult.IsValid.Should().BeFalse();
        invalidResult.Errors.Should().HaveCountGreaterThanOrEqualTo(2);
    }

    public sealed record SampleOrder(string OrderId, decimal Total);

    public sealed class SampleOrderValidator : AbstractValidator<SampleOrder>
    {
        public SampleOrderValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty();
            RuleFor(x => x.Total).GreaterThan(0);
        }
    }
}
