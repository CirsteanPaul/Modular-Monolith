using FluentValidation;

namespace WebApi.Configuration.Options;

public class ExampleOptionsValidator : AbstractValidator<ExampleOptions>
{
    public ExampleOptionsValidator()
    {
        RuleFor(x => x.Retries)
            .GreaterThan(0);
    }
}