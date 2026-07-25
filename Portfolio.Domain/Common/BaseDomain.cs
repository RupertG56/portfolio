namespace Portfolio.Domain.Common;

public class BaseDomain
{
    public string Id { get; init; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public bool Featured { get; set; } = false;
    public int SortOrder { get; set; } = 1;
    public bool IsPublished { get; set; } = false;
    public bool IsDeleted { get; set; } = false;
}