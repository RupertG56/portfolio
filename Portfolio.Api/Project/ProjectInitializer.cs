using Portfolio.Api.Initialization;

namespace Portfolio.Api.Project;

public class ProjectInitializer : IInitialize
{
    private readonly IMongoDatabase _database;

    public ProjectInitializer(IMongoDatabase database)
    {
        _database = database;
    }

    public async Task InitializeAsync()
    {
        // Implement your project initialization logic here
        // For example, you can seed the "project" collection with initial data
        var projectCollection = _database.GetCollection<Project>("project");

        var initialProjects = new List<Project>
        {
            new Project { Name = "Project 1", Description = "Description for Project 1" },
            new Project { Name = "Project 2", Description = "Description for Project 2" }
            // Add more initial projects as needed
        };

        await projectCollection.InsertManyAsync(initialProjects);
    }
}