using Portfolio.Api.Common;

namespace Portfolio.Api.Project;

public class ProjectService(IBaseDomainRepository<Project> projectRepository)
{
    private readonly IBaseDomainRepository<Project> _projectRepository = projectRepository;


}