using Portfolio.Api.Initialization;
using MongoDB.Driver;

namespace Portfolio.Api.Experience;

public class ExperienceInitializer(IMongoDatabase database) : IInitialize
{
    private readonly IMongoDatabase _database = database;

    public async Task InitializeAsync()
    {
        var experienceCollection = _database.GetCollection<ExperienceDocument>(ExperienceDocument.CollectionName);

        var experiences = new List<ExperienceDocument>
        {
            new()
            {
                Id = "retail-team-lead",
                Title = "Retail Team Lead",
                Company = "Maverik",
                Location = "West Jordan, UT",
                StartDate = new DateOnly(2024, 12, 9),
                EndDate = null,
                ResponsibilityMarkdown = """
                - Trained new team members by relaying information on company procedures and safety requirements.
                - Promoted a positive work environment fostering teamwork, open communication, and employee recognition initiatives.
                - Served as a role model for the team by demonstrating a strong work ethid, commitment to excellence, professionalism, and adherence to company values at all times.
                - Coached team members in techniques necessary to complete job tasks.
                """,
                IsDeleted = false,
                SortOrder = 1,
            },
            new()
            {
              Id = "senior-software-engineer",
              Title = "Senior Software Engineer",
              Company = "CaptionCall LLC",
              Location = "Salt Lake City, UT",
              StartDate = new DateOnly(2016, 11, 1),
              EndDate = new DateOnly(2020, 9, 30),
              ResponsibilityMarkdown =
              """
                - Buit, maintained, and extended CapNet using C# .NET. Implemented the frontend application following MVVM in WPF.
                - Handle messaging through transactional message bus, Tuxedo middleware.
                - De-coupled the system from external dependencies to allow for greater testing code-coverage and better support for TDD.
                - Designed and implemented the system (DAPS - Data Aquisition and Provisioning Server) to hnalde automated setup of VoIP accounts for mobile app VoIP using REST APIs.
                - Created new features for the back-end software infrastructure.
                - Created new SQL Server objects including stored procedures, functions, views, and triggers to support new features.
                - Followed SCRUM and agile methodologies to provide features faster and more efficiently.
                """,
                IsDeleted = false,
                SortOrder = 3,
            },
            new()
            {
                Id = "principal-software-engineer",
                Title = "Principal Software Engineer",
                Company = "CaptionCall LLC",
                Location = "Salt Lake City, UT",
                StartDate = new DateOnly(2020, 10, 1),
                EndDate = new DateOnly(2021, 4, 21),
                ResponsibilityMarkdown = """
                - Used REST APIs and ASP.NET Core to replace outdated and unsupported frameworkes.
                - Used C# and .NET Core to implement new features and functionality.
                - Migrated from .NET 4.5 to .NET 5
                - Established best practices in design methodologies and documentation across Git repositories., resulting in increased efficiency and consistency across projects.
                - Managed a small team of developers focusing on CapNet, the Captioning Agent WPF Application.
                - Designed new features using SignalR messaging to replace Tuxedo.
                """,
                IsDeleted = false,
                SortOrder = 2
            },
            new()
            {
                Id = "software-engineer-iii",
                Title = "Software Engineer I & II",
                Company = "CaptionCall LLC",
                Location = "Salt Lake City, UT",
                StartDate = new DateOnly(2014, 9, 1),
                EndDate = new DateOnly(2016, 10, 31),
                ResponsibilityMarkdown = """
                - Maintained C# WinForms application handling messages from Tuxedo message bus using polling.
                - Design solutions for CapNet following SOLID principles and best practices.
                - Participated in code reviews and provided feedback to improve code quality.
                - Use SIP protocol to handle call routing and attribute tagging for test calls.
                - Use Managed C++ and pure C++ for SIP development
                """,
                IsDeleted = false,
                SortOrder = 4
            },
            new()
            {
                Id = "software-developer",
                Title = "Software Developer",
                Company = "!800Radiator & A/C",
                Location = "Salt Lake City, UT",
                StartDate = new DateOnly(2007, 1, 9),
                EndDate = new DateOnly(2014, 9, 14),
                ResponsibilityMarkdown =
                """
                - Improved software efficieny through extensive profiling and debugging.
                - Utilized TDD to avoid bugs from the beginning of development and provide cleaner reduced bug code for production
                - Collaborated with cross-functional teams to deliver high-quality products on tight deadlines.
                - Enhanced user experience through designing and implementing user-friendly interfaces with jQuery and jQuery UI.
                - Use C# and MVC to build out the POS system
                - Developed the ecommerce application using PHP and CodeIgniter.
                - Third-party API integrations (i.e. credit card processing)
                - Operated in a semi-agile development environment
                """,
                IsDeleted = false,
                SortOrder = 5
            }
            // Add more experiences as needed
        };

        await experienceCollection.InsertManyAsync(experiences);
    }
}