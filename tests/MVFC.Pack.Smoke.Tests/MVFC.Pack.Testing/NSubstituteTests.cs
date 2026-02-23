namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Testing;

public sealed class NSubstituteTests
{
    [Fact]
    public void NSubstitute_Types_Should_Be_Accessible()
    {
        typeof(Substitute).Should().NotBeNull();
        typeof(Arg).Should().NotBeNull();
    }

    [Fact]
    public void NSubstitute_Should_Create_Substitute_At_Runtime()
    {
        var fake = Substitute.For<IDisposable>();

        fake.Should().NotBeNull();
    }

    [Fact]
    public void NSubstitute_Should_Setup_Return_Values()
    {
        var calculator = Substitute.For<ISampleCalculator>();
        calculator.Add(2, 3).Returns(5);

        var result = calculator.Add(2, 3);

        result.Should().Be(5);
        calculator.Received(1).Add(2, 3);
    }

    public interface ISampleCalculator
    {
        public int Add(int a, int b);
    }
}
