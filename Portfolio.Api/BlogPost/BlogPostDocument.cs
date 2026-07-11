using Portfolio.Api.Common;

namespace Portfolio.Api.BlogPost;

// Blog post document stored in the data store. Inherits common document fields from DocumentBase.
public class BlogPostDocument : BaseDocument
{
    public const string CollectionName = "blogPost";
    public string Author { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    // The blog post content in Markdown format
    public string ContentMarkdown { get; set; } = string.Empty;
    public int Revision { get; set; } = 1;
    public string? InternalNotes { get; set; } = null;
}

