using MongoDB.Driver;
using Portfolio.Api.Site;

namespace Portfolio.Api.Initialization;

public static class DatabaseInitializer
{
    public static async Task ResetAndSeedAsync(IMongoDatabase database)
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

        await SeedSiteAsync(database);
        //await SeedSkillsAsync(database);
        //await SeedProjectsAsync(database);
        //await SeedExperienceAsync(database);
        //await CreateIndexesAsync(database);
    }

    private static async Task SeedSiteAsync(IMongoDatabase database)
    {
        var siteCollection = database.GetCollection<SiteDocument>("site");

        var siteDocument = new SiteDocument
        {
            Id = "site",
            Title = "My Portfolio",
            TagLine = "Welcome to my portfolio website.",
            AboutMarkdown = "# About Me\n\nThis is a sample portfolio website built with ASP.NET Core and MongoDB.",
            ResumeUrl = "/files/PrincipalResume.pdf",
            ContactInfo = new ContactInfo(
                email: "rupertg56@gmail.com",
                phone: "801-897-4701",
                address: new Address(
                    street: "8329 S Mascaro Way",
                    city: "West Jordan",
                    state: "UT",
                    zipCode: "84081"
                )
            )
        };

        await siteCollection.InsertOneAsync(siteDocument);
    }
}