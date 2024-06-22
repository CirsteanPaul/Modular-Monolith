namespace WebApi.Configuration.Options;

public class ExampleOptions
{
    public const string SectionName = "Example";
    public required int Retries { get; init; }
}