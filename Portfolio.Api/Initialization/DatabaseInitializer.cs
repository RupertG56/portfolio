using MongoDB.Driver;
using Portfolio.Api.Site;
using Portfolio.Api.SkillCategory;

namespace Portfolio.Api.Initialization;

public static class DatabaseInitializer
{
    public static async Task ResetAndInitializeAsync(IMongoDatabase database)
    {
        var collections = new[]
        {
            "site",
            "skillCategory",
            "experience",
            "project",
            "blogPost",
            "education",
            "certification"
        };

        foreach (var collection in collections)
        {
            await database.DropCollectionAsync(collection);
        }

        await new SiteInitializer(database).InitializeAsync();
        await new SkillCategoryInitializer(database).InitializeAsync();
        //await SeedProjectsAsync(database);
        //await SeedExperienceAsync(database);
        //await CreateIndexesAsync(database);
    }
}