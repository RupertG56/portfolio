using Portfolio.Domain.Project;
using Portfolio.Api.Common;

namespace Portfolio.Api.Project;

public sealed class ProjectDocument : BaseDocument
{
    public const string CollectionName = "project";
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