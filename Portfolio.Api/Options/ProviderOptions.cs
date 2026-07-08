namespace Portfolio.Api.Options;

public sealed class ProviderOptions
{
    public const string SectionName = "Mongo";
    public string ConnectionString { get; init; } = string.Empty;
    public string DatabaseName { get; init; } = string.Empty;
}