using MongoDB.Driver;
using Portfolio.Api.Initialization;

namespace Portfolio.Api.Education;

public class EducationInitializer : IInitialize
{
    private readonly IMongoDatabase _database;

    public EducationInitializer(IMongoDatabase database)
    {
        _database = database;
    }

    public async Task InitializeAsync()
    {
        // Implement your education initialization logic here
        // For example, you can seed the "education" collection with initial data
        var educationCollection = _database.GetCollection<EducationDocument>(EducationDocument.CollectionName);

        var initialEducationEntries = new List<EducationDocument>
        {
            new() {
                Id = "weber-state-university",
                Institution = "Weber State University",
                Location = "Ogden, Utah",
                StartDate = new DateOnly(2006, 1, 1),
                EndDate = new DateOnly(2010, 6, 30),
                Degree = "Bachelor of Science",
                FieldOfStudy = "Computer Science",
                DescriptionMarkdown = """
                # Weber State University
                
                I attended this university remotely via the internet and
                classes offered on the SLCC campuses. I graduated with a Bachelor of Science in Computer Science.
                """,
                Highlights = ["Graduated with honors", "Summa Cum Laude", "3.92 GPA"],
                SortOrder = 1
            }
            // Add more initial education entries as needed
        };

        await educationCollection.InsertManyAsync(initialEducationEntries);
    }
}