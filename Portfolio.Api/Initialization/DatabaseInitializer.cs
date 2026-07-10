using MongoDB.Driver;
using Portfolio.Api.Education;
using Portfolio.Api.Experience;
using Portfolio.Api.Project;
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
        await new EducationInitializer(database).InitializeAsync();
        await new ProjectInitializer(database).InitializeAsync();
        await new ExperienceInitializer(database).InitializeAsync();
        //await CreateIndexesAsync(database);
    }
}