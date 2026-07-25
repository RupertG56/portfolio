namespace Portfolio.Domain.Common;

public class ResumeEntryBaseDomain
{
    public string Id { get; init; } = string.Empty;

    public int SortOrder { get; set; } = 1;
}