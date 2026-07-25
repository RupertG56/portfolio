namespace Portfolio.Domain.Common;

public class BaseDomain
{
    public string Id { get; init; } = string.Empty;
    public string Title { get; set; } = string.Empty;
    public bool Featured { get; set; }
    public int SortOrder { get; set; } = 1;
    public bool IsPublished { get; set; }
    public bool IsDeleted { get; set; }
}