namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Domain;

public sealed class FluentResultsTests
{
    [Fact]
    public void FluentResults_Types_Should_Be_Accessible()
    {
        typeof(Result).Should().NotBeNull();
        typeof(Result<>).Should().NotBeNull();
    }

    [Fact]
    public void FluentResults_Ok_Should_Be_Success()
    {
        var result = Result.Ok();

        result.IsSuccess.Should().BeTrue();
        result.IsFailed.Should().BeFalse();
    }

    [Fact]
    public void FluentResults_Fail_Should_Be_Failed()
    {
        var result = Result.Fail("Algo deu errado");

        result.IsFailed.Should().BeTrue();
        result.IsSuccess.Should().BeFalse();
        result.Errors.Should().ContainSingle().Which.Message.Should().Be("Algo deu errado");
    }

    [Fact]
    public void FluentResults_Ok_With_Value_Should_Return_Value()
    {
        var result = Result.Ok(42);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be(42);
    }
}
