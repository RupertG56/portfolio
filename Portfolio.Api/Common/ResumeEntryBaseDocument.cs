using MongoDB.Bson.Serialization.Attributes;

namespace Portfolio.Api.Common;

public abstract class ResumeEntryBaseDocument
{
    [BsonId]
    public string Id { get; init; } = string.Empty;

    public int SortOrder { get; set; } = 1;

    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }
}