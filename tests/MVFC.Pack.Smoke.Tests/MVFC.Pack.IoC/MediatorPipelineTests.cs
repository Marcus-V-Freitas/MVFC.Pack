namespace MVFC.Pack.Smoke.Tests.MVFC.Pack.IoC;

public sealed record ValidatedCommand(string Name, int Age) : IRequest<Result<string>>;

public sealed class ValidatedCommandValidator : AbstractValidator<ValidatedCommand>
{
    public ValidatedCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Nome é obrigatório");
        RuleFor(x => x.Age).GreaterThanOrEqualTo(18).WithMessage("Idade mínima é 18 anos");
    }
}

public sealed class ValidatedCommandHandler : IRequestHandler<ValidatedCommand, Result<string>>
{
    public async Task<Result<string>> Handle(ValidatedCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);

        return await Task.FromResult(Result.Ok($"Bem-vindo, {command.Name}!")).ConfigureAwait(true);
    }
        
}

public sealed class ValidationPipelineBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    where TResponse : ResultBase, new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators = validators;

    public async Task<TResponse> Handle(
        TRequest message,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentNullException.ThrowIfNull(next);

        var context = new ValidationContext<TRequest>(message);
        var failures = _validators
            .Select(v => v.Validate(context))
            .SelectMany(r => r.Errors)
            .Where(e => e is not null)
            .ToList();

        if (failures.Count > 0)
        {
            var result = new TResponse();
            foreach (var failure in failures)
                result.Reasons.Add(new FluentResults.Error(failure.ErrorMessage));
            return result;
        }

        return await next(cancellationToken).ConfigureAwait(true);
    }
}

public sealed class MediatorPipelineTests
{
    [Fact]
    public async Task Pipeline_Should_Allow_Valid_Command_Through()
    {
        var services = new ServiceCollection();
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(ValidatedCommand).Assembly);
            cfg.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
        });
        services.AddValidatorsFromAssemblyContaining<ValidatedCommandValidator>();

        using var provider = services.BuildServiceProvider();
        var mediator = provider.GetRequiredService<IMediator>();

        var result = await mediator.Send(new ValidatedCommand("Marcus", 25), TestContext.Current.CancellationToken);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().Be("Bem-vindo, Marcus!");
    }
}
