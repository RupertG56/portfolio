using MongoDB.Bson.Serialization.Attributes;

namespace Portfolio.Api.Base;
/*

 * Base class for documents stored in MongoDB.
 {
	"_id": "",
	"title": "",
	"slug": "",
	"summary": "",
	"featured": false,
	"sortOrder": 1,
	"isPublished": false,
	"createdAt": "2026-07-06T00:00:00Z",
	"updatedAt": "2026-07-06T00:00:00Z"
};
 */
public abstract class BaseDocument
{
	[BsonId]
	public string Id { get; init; } = string.Empty;
	public string Title { get; set; } = string.Empty;
	public bool Featured { get; set; } = false;
	public int SortOrder { get; set; } = 1;
	public bool IsPublished { get; set; } = false;
	public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
	public DateTime? UpdatedAt { get; set; } = null;
}