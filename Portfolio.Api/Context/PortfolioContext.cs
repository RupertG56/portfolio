using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Portfolio.Api.Options;
using Portfolio.Api.BlogPost;
using Portfolio.Api.Education;
using Portfolio.Api.Experience;
using Portfolio.Api.Project;
using Portfolio.Api.Site;

namespace Portfolio.Api.Context;

public class PortfolioContext
{
    private readonly IMongoClient _mongoClient;
    private readonly IMongoDatabase _database;

    public PortfolioContext(IMongoClient mongoClient, IOptions<ProviderOptions> options)
    {
        _mongoClient = mongoClient;
        _database = _mongoClient.GetDatabase(options.Value.DatabaseName);
    }

    public IMongoDatabase Database => _database;

    public IMongoCollection<ProjectDocument> Projects =>
        GetCollection<ProjectDocument>(ProjectDocument.CollectionName);

    public IMongoCollection<ExperienceDocument> Experience =>
        GetCollection<ExperienceDocument>(ExperienceDocument.CollectionName);

    public IMongoCollection<BlogPostDocument> BlogPosts =>
        GetCollection<BlogPostDocument>(BlogPostDocument.CollectionName);

    public IMongoCollection<SiteDocument> Site =>
        GetCollection<SiteDocument>(SiteDocument.CollectionName);

    public IMongoCollection<EducationDocument> Education =>
        GetCollection<EducationDocument>(EducationDocument.CollectionName);

    private IMongoCollection<T> GetCollection<T>(string name)
    {
        return _database.GetCollection<T>(name);
    }
}