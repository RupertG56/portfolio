using Microsoft.AspNetCore.Razor.TagHelpers;
using MongoDB.Driver;
using Portfolio.Api.Initialization;

namespace Portfolio.Api.Project;

public class ProjectInitializer(IMongoDatabase database) : IInitialize
{
    private readonly IMongoDatabase _database = database;

    public async Task InitializeAsync()
    {
        // Implement your project initialization logic here
        // For example, you can seed the "project" collection with initial data
        var projectCollection = _database.GetCollection<ProjectDocument>("project");

        var initialProjects = new List<ProjectDocument>
        {
            new()
            {
                Id = "portfolio-website",
                Featured = true,
                SortOrder = 1,
                IsPublished = true,
                Title = "Portfolio Website",
                DescriptionMarkdown =
                """
                # Portfolio Website
                """,

            },
            new()
            {
                Id = "factorio-server",
                Featured = true,
                SortOrder = 2,
                IsPublished = true,
                Title = "Factorio Servers",
                Summary = "Containerized Factorio Dedicated Server Infrastructure",
                DescriptionMarkdown = """
                - Designed automated conatiner deployment for game servers using rootless Podman
                - Implemented systemd quadlets for container lifecycle management and automation
                - Built monitoring scripts to manage uptime and log analysis.
                """,
                CompletedOn = new DateOnly(2026, 2, 10),
                Technologies =
                [
                    new Technology
                    {
                        Featured = true,
                        Name = "Linux",
                        Url = "https://www.linux.org/"
                    },
                    new Technology
                    {
                        Featured = true,
                        Name = "Podman",
                        Url = "https://podman.io"
                    },
                    new Technology
                    {
                        Featured = true,
                        Name = "systemd",
                        Url = "https://systemd.io"
                    },
                    new Technology
                    {
                        Featured = true,
                        Name = "Networking",
                        Url = string.Empty
                    }
                ],

            },
            new()
            {
                Id = "media-encoding-automation",
                Title = "Media Encoding Automation",
                Summary = "Using ffmpeg with bash scripts to automated encoding tv series and movies",
                Technologies =
                [
                    new()
                    {
                        Featured = true,
                        Name = "FFmpeg",
                        Url = "https://www.ffmpeg.org/"
                    },
                    new()
                    {
                        Featured = true,
                        Name = "Bash",
                        Url = "https://en.wikipedia.org/wiki/Bash_(Unix_shell)"
                    },
                    new()
                    {
                        Featured = true,
                        Name = "Linux",
                        Url = "https://www.linux.org/"
                    }
                ],
                CompletedOn = new DateOnly(2026, 3, 23),
                DescriptionMarkdown =
                """
                - Developed automated scripts to transcode media libraries to HEVC (H.265)
                - Implemented parallel processing pipelines to optimize encoding throughput
                """
            }
            // Add more initial projects as needed
        };

        await projectCollection.InsertManyAsync(initialProjects);
    }
}