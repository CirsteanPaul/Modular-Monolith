using FluentValidation;
using Microsoft.Extensions.Options;

namespace WebApi.Configuration.Extensions;

public static class OptionsBuilderFluentValidationExtensions
{
    public static OptionsBuilder<TOptions> ValidateFluently<TOptions>(this OptionsBuilder<TOptions> optionsBuilder)
        where TOptions : class
    {
        optionsBuilder.Services.AddSingleton<IValidateOptions<TOptions>>(s => 
            new FluentValidationOptions<TOptions>(optionsBuilder.Name, s.GetRequiredService<IValidator<TOptions>>()));
        return optionsBuilder;
    }
}

public class FluentValidationOptions<TOptions> : IValidateOptions<TOptions> where TOptions : class
{
    private readonly IValidator<TOptions> validator;
    public FluentValidationOptions(string name, IValidator<TOptions> validator)
    {
        Name = name;
        this.validator = validator;
    }
    
    public string Name { get; }
    
    public ValidateOptionsResult Validate(string name, TOptions options)
    {
        if (Name != null && name != Name)
        {
            return ValidateOptionsResult.Skip;
        }
        
        ArgumentNullException.ThrowIfNull(options);

        var validateResult = validator.Validate(options);

        if (validateResult.IsValid)
        {
            return ValidateOptionsResult.Success;
        }

        var errors = validateResult.Errors.Select(x =>
            $"Options validations failed for {x.PropertyName} with error: '{x.ErrorMessage}'.");
        
        return ValidateOptionsResult.Fail(errors);
    }
}