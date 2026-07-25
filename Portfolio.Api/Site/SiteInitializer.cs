using MongoDB.Driver;
using Portfolio.Api.Initialization;
using Portfolio.Domain.Site;

namespace Portfolio.Api.Site;

public class SiteInitializer : IInitialize
{
    private readonly IMongoDatabase _database;

    public SiteInitializer(IMongoDatabase database)
    {
        _database = database;
    }

    public async Task InitializeAsync()
    {
        var siteCollection = _database.GetCollection<SiteDocument>(SiteDocument.CollectionName);

        // Check if the collection is empty
        var count = await siteCollection.CountDocumentsAsync(FilterDefinition<SiteDocument>.Empty);
        if (count == 0)
        {
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
}