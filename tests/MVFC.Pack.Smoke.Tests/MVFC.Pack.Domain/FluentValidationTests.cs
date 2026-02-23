namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Domain;

public sealed class FluentValidationTests
{
    [Fact]
    public void FluentValidation_Types_Should_Be_Accessible()
    {
        typeof(IValidator<>).Should().NotBeNull();
        typeof(AbstractValidator<>).Should().NotBeNull();
        typeof(ValidationResult).Should().NotBeNull();
    }

    [Fact]
    public void FluentValidation_Should_Validate_Valid_Object()
    {
        var validator = new SamplePersonValidator();
        var person = new SamplePerson("Marcus", 25);

        var result = validator.Validate(person);

        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }

    [Fact]
    public void FluentValidation_Should_Fail_For_Invalid_Object()
    {
        var validator = new SamplePersonValidator();
        var person = new SamplePerson("", -1);

        var result = validator.Validate(person);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().HaveCountGreaterThanOrEqualTo(2);
    }

    private sealed record SamplePerson(string Name, int Age);

    private sealed class SamplePersonValidator : AbstractValidator<SamplePerson>
    {
        public SamplePersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Age).GreaterThanOrEqualTo(0);
        }
    }
}
