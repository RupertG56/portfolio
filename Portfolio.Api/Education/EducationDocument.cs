using MongoDB.Bson.Serialization.Attributes;
using Portfolio.Api.Base;

namespace Portfolio.Api.Education;

public sealed class EducationDocument : ResumeEntryDocumentBase
{
    public const string CollectionName = "education";
    public string Institution { get; set; } = string.Empty;
    public string? Location { get; set; } = string.Empty;
    public DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Today);
    public DateOnly? EndDate { get; set; } = null;
    public string? Degree { get; set; } = string.Empty;
    public string? DescriptionMarkdown { get; set; } = string.Empty;
    public string? FieldOfStudy { get; set; } = string.Empty;
    public List<string> Highlights { get; set; } = [];
    public bool IsDeleted { get; set; } = false;
    public string? InternalNotes { get; set; } = null;
}