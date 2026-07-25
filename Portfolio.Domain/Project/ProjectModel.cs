using Portfolio.Domain.Common;

namespace Portfolio.Domain.Project;

public class ProjectModel : BaseDomain
{
    /// <summary>
    /// Short description used in cards and project lists.
    /// </summary>
    public string Summary { get; set; } = string.Empty;

    /// <summary>
    /// Full project write-up in Markdown.
    /// </summary>
    public string DescriptionMarkdown { get; set; } = string.Empty;

    /// <summary>
    /// Technologies used in the project.
    /// </summary>
    public List<Technology> Technologies { get; init; } = [];

    /// <summary>
    /// Links related to the project.
    /// </summary>
    public ProjectLinks Links { get; init; } = new();

    /// <summary>
    /// Images displayed in the project gallery.
    /// </summary>
    public List<ProjectImage> Images { get; init; } = [];

    /// <summary>
    /// Optional project completion date.
    /// </summary>
    public DateOnly? CompletedOn { get; set; }
}

public sealed class ProjectImage
{
    public string Url { get; init; } = string.Empty;

    public string AltText { get; init; } = string.Empty;

    public int SortOrder { get; init; }
}

public sealed class Technology
{
    public string Name { get; init; } = string.Empty;

    public bool Featured { get; init; }

    public string? Url { get; init; }

    public string? Icon { get; init; }
}

public sealed class ProjectLinks
{
    public string? Demo { get; set; }
    public string? GitHub { get; set; }
    public string? Documentation { get; set; }
}