using MongoDB.Driver;
using Portfolio.Api.BlogPost;
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

        await database.DropCollectionAsync(SiteDocument.CollectionName);
        await database.DropCollectionAsync(SkillCategoryDocument.CollectionName);
        await database.DropCollectionAsync(EducationDocument.CollectionName);
        await database.DropCollectionAsync(ProjectDocument.CollectionName);
        await database.DropCollectionAsync(ExperienceDocument.CollectionName);
        await database.DropCollectionAsync(BlogPostDocument.CollectionName);

        await new SiteInitializer(database).InitializeAsync();
        await new SkillCategoryInitializer(database).InitializeAsync();
        await new EducationInitializer(database).InitializeAsync();
        await new ProjectInitializer(database).InitializeAsync();
        await new ExperienceInitializer(database).InitializeAsync();
        await new BlogPostInitializer(database).InitializeAsync();
        //await CreateIndexesAsync(database);
    }
}