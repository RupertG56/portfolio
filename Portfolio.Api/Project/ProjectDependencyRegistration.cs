using Portfolio.Api.Common;
using Portfolio.Domain.Project;
namespace Portfolio.Api.Project;

public static class ProjectDependencyRegistration
{
    public static void AddProjectDependencies(this IServiceCollection services)
    {
        services.AddScoped<IBaseDomainRepository<ProjectModel>, ProjectRepository>();
        services.AddScoped<IProjectService, ProjectService>();
    }
}
