namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Testing;

public sealed class FluentAssertionsTests
{
    [Fact]
    public void FluentAssertions_Types_Should_Be_Accessible()
    {
        typeof(AssertionOptions).Should().NotBeNull();
        typeof(StringAssertions).Should().NotBeNull();
    }

    [Fact]
    public void FluentAssertions_Should_Assert_Strings()
    {
        var name = "MVFC.Pack";

        name.Should().StartWith("MVFC");
        name.Should().Contain("Pack");
        name.Should().HaveLength(9);
    }

    [Fact]
    public void FluentAssertions_Should_Assert_Collections()
    {
        var numbers = new[] { 1, 2, 3, 4, 5 };

        numbers.Should().HaveCount(5);
        numbers.Should().Contain(3);
        numbers.Should().BeInAscendingOrder();
        numbers.Should().OnlyContain(n => n > 0);
    }

    [Fact]
    public void FluentAssertions_Should_Assert_Numeric()
    {
        var value = 42;

        value.Should().BePositive();
        value.Should().BeGreaterThan(40);
        value.Should().BeInRange(1, 100);
    }

    [Fact]
    public void FluentAssertions_Should_Assert_Exceptions()
    {
        Action action = () => throw new InvalidOperationException("test error");

        action.Should().Throw<InvalidOperationException>()
            .WithMessage("test error");
    }
}
