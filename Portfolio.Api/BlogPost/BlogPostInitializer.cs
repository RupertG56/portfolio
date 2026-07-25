using Portfolio.Api.Initialization;
using MongoDB.Driver;

namespace Portfolio.Api.BlogPost;

public class BlogPostInitializer(IMongoDatabase mongoDatabase) : IInitialize
{
    private readonly IMongoDatabase _mongoDatabase = mongoDatabase;
    private readonly List<BlogPostDocument> _samplePosts = new()
    {
        new BlogPostDocument
        {
            Id = "getting-started-with-csharp",
            Title = "Getting Started with C#",
            ContentMarkdown = """
			# Learn the basics of C# programming language and its core concepts.
			""",
            Author = "Ryan Jones",
            CreatedAt = System.DateTime.UtcNow.AddDays(-10),
            IsPublished = true,
        },
        new BlogPostDocument
        {
            Id = "aspnet-core-best-practices",
            Title = "ASP.NET Core Best Practices",
            ContentMarkdown = "Explore industry best practices for building scalable ASP.NET Core applications.",
            Author = "Jane Smith",
            CreatedAt = DateTime.UtcNow.AddDays(-5),
            IsPublished = true,
        },
        new BlogPostDocument
        {
            Id = "building-restful-apis",
            Title = "Building RESTful APIs",
            ContentMarkdown = "A comprehensive guide to designing and implementing RESTful APIs with proper HTTP methods and status codes.",
            Author = "Bob Johnson",
            CreatedAt = DateTime.UtcNow.AddDays(-2),
            IsPublished = true,
        }
    };

    // Provide an async-friendly variant if consumers expect it.
    public async Task InitializeAsync()
    {
        var blogPostCollection = _mongoDatabase.GetCollection<BlogPostDocument>(BlogPostDocument.CollectionName);
        await blogPostCollection.InsertManyAsync(_samplePosts);
    }
}