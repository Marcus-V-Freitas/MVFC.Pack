namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.Domain;

public sealed class FluentResultsAdvancedTests
{
    [Fact]
    public void Result_Should_Chain_WithSuccess()
    {
        var result = Result.Ok()
            .WithSuccess("Pedido criado")
            .WithSuccess("Email enviado");

        result.IsSuccess.Should().BeTrue();
        result.Successes.Should().HaveCount(2);
        result.Successes[0].Message.Should().Be("Pedido criado");
        result.Successes[1].Message.Should().Be("Email enviado");
    }

    [Fact]
    public void Result_Should_Chain_Multiple_Errors()
    {
        var result = Result.Fail("Erro 1")
            .WithError("Erro 2")
            .WithError("Erro 3");

        result.IsFailed.Should().BeTrue();
        result.Errors.Should().HaveCount(3);
    }

    [Fact]
    public void Result_Should_Merge_Multiple_Results()
    {
        var result1 = Result.Ok().WithSuccess("Passo 1 OK");
        var result2 = Result.Fail("Passo 2 falhou");
        var result3 = Result.Ok().WithSuccess("Passo 3 OK");

        var merged = Result.Merge(result1, result2, result3);

        merged.IsFailed.Should().BeTrue();
        merged.Successes.Should().HaveCount(2);
        merged.Errors.Should().ContainSingle();
    }

    [Fact]
    public void ResultT_Should_Map_Value()
    {
        var result = Result.Ok(10);

        var doubled = result.IsSuccess
            ? Result.Ok(result.Value * 2)
            : Result.Fail<int>("Falhou");

        doubled.IsSuccess.Should().BeTrue();
        doubled.Value.Should().Be(20);
    }

    [Fact]
    public void ResultT_Should_Work_With_Complex_Types()
    {
        var order = new OrderDto(Guid.NewGuid(), "Notebook", 3, 4500.00m);
        var result = Result.Ok(order);

        result.IsSuccess.Should().BeTrue();
        result.Value.ProductName.Should().Be("Notebook");
        result.Value.Quantity.Should().Be(3);
        result.Value.Total.Should().Be(4500.00m);
        result.Value.Id.Should().NotBeEmpty();
    }

    [Fact]
    public void Result_Should_Convert_ToResult_Generic()
    {
        var success = Result.Ok();
        var typedSuccess = success.ToResult(42);

        typedSuccess.IsSuccess.Should().BeTrue();
        typedSuccess.Value.Should().Be(42);

        var failure = Result.Fail("Falhou");
        var typedFailure = failure.ToResult<int>();

        typedFailure.IsFailed.Should().BeTrue();
    }

    [Fact]
    public void Result_Should_Use_Custom_Error()
    {
        var result = Result.Fail(new NotFoundError("Pedido", "ORD-999"));

        result.IsFailed.Should().BeTrue();
        result.Errors.Should().ContainSingle()
            .Which.Should().BeOfType<NotFoundError>();

        var error = (NotFoundError)result.Errors[0];
        error.Entity.Should().Be("Pedido");
        error.Identifier.Should().Be("ORD-999");
    }

    private sealed record OrderDto(Guid Id, string ProductName, int Quantity, decimal Total);

    private sealed class NotFoundError(string entity, string identifier) : Error($"{entity} '{identifier}' não encontrado")
    {
        public string Entity { get; } = entity;

        public string Identifier { get; } = identifier;
    }
}
