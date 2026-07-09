using MongoDB.Driver;
using Portfolio.Api.Initialization;

namespace Portfolio.Api.SkillCategory;

public class SkillCategoryInitializer(IMongoDatabase database) : IInitialize
{
    private readonly IMongoDatabase _database = database;

    public async Task InitializeAsync()
    {
        var skillCategoryCollection = _database.GetCollection<SkillCategoryDocument>("skillCategory");

        var skillCategories = new List<SkillCategoryDocument>
        {
            new() {
                Id = "programming-languages",
                Name = "Programming Languages",
                Skills =
                [
                    new SkillDocument { Name = "C#", ReferenceUrl = "https://docs.microsoft.com/en-us/dotnet/csharp/", CategoryId = "programming-languages" },
                    new SkillDocument { Name = "C++", ReferenceUrl = "https://isocpp.org/", CategoryId = "programming-languages" },
                    new SkillDocument { Name = "Typescript", ReferenceUrl = "https://www.typescriptlang.org/", CategoryId = "programming-languages" },
                    new SkillDocument { Name = "JavaScript", ReferenceUrl = "https://developer.mozilla.org/en-US/docs/Web/JavaScript", CategoryId = "programming-languages" },
                    new SkillDocument { Name = "Python", ReferenceUrl = "https://www.python.org/", CategoryId = "programming-languages" },
                    new SkillDocument { Name = "Bash", ReferenceUrl = "https://www.gnu.org/software/bash/", CategoryId = "programming-languages" },
                    new SkillDocument { Name = "PowerShell", ReferenceUrl = "https://docs.microsoft.com/en-us/powershell/", CategoryId = "programming-languages" },
                ],
                SortOrder = 1
            },
            new() {
                Id = "frameworks",
                Name = "Frameworks",
                Skills =
                [
                    new SkillDocument { Name = ".NET Framework", ReferenceUrl = "https://dotnet.microsoft.com/en-us/apps/desktop/dotnet-framework", CategoryId = "frameworks" },
                    new SkillDocument { Name = ".NET Core", ReferenceUrl = "https://docs.microsoft.com/en-us/dotnet/core/", CategoryId = "frameworks" },
                    new SkillDocument { Name = "ASP.NET Core", ReferenceUrl = "https://docs.microsoft.com/en-us/aspnet/core/", CategoryId = "frameworks" },
                    new SkillDocument { Name = "React", ReferenceUrl = "https://reactjs.org/", CategoryId = "frameworks" },
                    new SkillDocument { Name = "Vue.js", ReferenceUrl = "https://vuejs.org/", CategoryId = "frameworks" },
                    new SkillDocument { Name = "SignalR", ReferenceUrl = "https://dotnet.microsoft.com/apps/aspnet/signalr", CategoryId = "concepts" }
                ],
                SortOrder = 2
            },
            new()
            {
                Id = "infrastructure",
                Name = "Infrastructure",
                Skills =
                [
                    new SkillDocument { Name = "Docker", ReferenceUrl = "https://www.docker.com/", CategoryId = "infrastructure" },
                    new SkillDocument { Name = "Podman", ReferenceUrl = "https://podman.io/", CategoryId = "infrastructure" },
                    new SkillDocument { Name = "Linux", ReferenceUrl = "https://www.kernel.org/", CategoryId = "infrastructure" },
                    new SkillDocument { Name = "Systemd", ReferenceUrl = "https://www.freedesktop.org/wiki/Software/systemd/", CategoryId = "infrastructure" },
                    new SkillDocument { Name = "Containerization", ReferenceUrl = "https://en.wikipedia.org/wiki/Containerization_(computing)", CategoryId = "infrastructure" }
                ],
                SortOrder = 3
            },
            new()
            {
                Id = "databases",
                Name = "Databases",
                Skills =
                [
                    new SkillDocument { Name = "MongoDB", ReferenceUrl = "https://www.mongodb.com/", CategoryId = "databases" },
                    new SkillDocument { Name = "MySQL", ReferenceUrl = "https://www.mysql.com/", CategoryId = "databases" },
                    new SkillDocument { Name = "SQL Server", ReferenceUrl = "https://www.microsoft.com/en-us/sql-server/sql-server-downloads", CategoryId = "databases" },
                    new SkillDocument { Name = "SQLite", ReferenceUrl = "https://www.sqlite.org/index.html", CategoryId = "databases" },
                    new SkillDocument { Name = "Redis", ReferenceUrl = "https://redis.io/", CategoryId = "databases" }
                ],
                SortOrder = 5
            },
            new()
            {
                Id = "cloud-services-devops",
                Name = "Cloud & DevOps",
                Skills =
                [
                    new SkillDocument { Name = "AWS", ReferenceUrl = "https://aws.amazon.com/", CategoryId = "cloud-services-devops" },
                    new SkillDocument { Name = "Azure", ReferenceUrl = "https://azure.microsoft.com/", CategoryId = "cloud-services-devops" },
                    new SkillDocument { Name = "CI/CD", ReferenceUrl = "https://en.wikipedia.org/wiki/Continuous_integration", CategoryId = "cloud-services-devops" },
                    new SkillDocument { Name = "Git", ReferenceUrl = "https://git-scm.com/", CategoryId = "cloud-services-devops" },
                    new SkillDocument { Name = "GitHub Actions", ReferenceUrl = "https://github.com/features/actions", CategoryId = "cloud-services-devops" }
                ],
                SortOrder = 4
            },
            new()
            {
                Id = "testing",
                Name = "Testing",
                Skills =
                [
                    new SkillDocument { Name = "Unit Testing", ReferenceUrl = "https://en.wikipedia.org/wiki/Unit_testing", CategoryId = "testing" },
                    new SkillDocument { Name = "Integration Testing", ReferenceUrl = "https://en.wikipedia.org/wiki/Integration_testing", CategoryId = "testing" },
                    new SkillDocument { Name = "End-to-End Testing", ReferenceUrl = "https://en.wikipedia.org/wiki/End-to-end_testing", CategoryId = "testing" }
                ],
                SortOrder = 6
            },
            new()
            {
                Id = "programming-paradigms",
                Name = "Programming Paradigms",
                Skills =
                [
                    new SkillDocument { Name = "Object-Oriented Programming (OOP)", ReferenceUrl = "https://en.wikipedia.org/wiki/Object-oriented_programming", CategoryId = "programming-paradigms" },
                    new SkillDocument { Name = "Functional Programming", ReferenceUrl = "https://en.wikipedia.org/wiki/Functional_programming", CategoryId = "programming-paradigms" }
                ],
                SortOrder = 8
            },
            new()
            {
                Id = "architecture-design-patterns",
                Name = "Architecture & Design Patterns",
                Skills =
                [
                    new SkillDocument { Name = "Singleton", ReferenceUrl = "https://en.wikipedia.org/wiki/Singleton_pattern", CategoryId = "architecture-design-patterns" },
                    new SkillDocument { Name = "Factory Method", ReferenceUrl = "https://en.wikipedia.org/wiki/Factory_method_pattern", CategoryId = "architecture-design-patterns" },
                    new SkillDocument { Name = "Observer", ReferenceUrl = "https://en.wikipedia.org/wiki/Observer_pattern", CategoryId = "architecture-design-patterns" },
                    new SkillDocument { Name = "Design Patterns", ReferenceUrl = "https://en.wikipedia.org/wiki/Software_design_pattern", CategoryId = "architecture-design-patterns" },
                    new SkillDocument { Name = "SOLID Principles", ReferenceUrl = "https://en.wikipedia.org/wiki/SOLID", CategoryId = "architecture-design-patterns" },
                    new SkillDocument { Name = "RESTful APIs", ReferenceUrl = "https://en.wikipedia.org/wiki/Representational_state_transfer", CategoryId = "architecture-design-patterns" },
                    new SkillDocument { Name = "Microservices", ReferenceUrl = "https://en.wikipedia.org/wiki/Microservices", CategoryId = "architecture-design-patterns" },
                    new SkillDocument { Name = "Event-Driven Architecture", ReferenceUrl = "https://en.wikipedia.org/wiki/Event-driven_architecture", CategoryId = "architecture-design-patterns" }
                ],
                SortOrder = 7
            }
        };

        await skillCategoryCollection.InsertManyAsync(skillCategories);
    }
}