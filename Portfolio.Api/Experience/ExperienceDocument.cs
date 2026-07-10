using Portfolio.Api.Base;

namespace Portfolio.Api.Experience;

public sealed class ExperienceDocument : ResumeEntryDocumentBase
{
    public const string CollectionName = "experience";
    public string Title { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    public DateOnly? EndDate { get; set; } = null;
    public string ResponsibilityMarkdown { get; set; } = string.Empty;
    public bool IsDeleted { get; set; } = false;
    public string? InternalNotes { get; set; } = null;
}