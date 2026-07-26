using Portfolio.Api.Common;
using Portfolio.Domain.Project;
using Portfolio.Contracts.Project;
using Portfolio.Contracts.Common;

namespace Portfolio.Api.Project;

public interface IProjectService
{
    Task<ResponseDto<List<ProjectSummaryDto>>> GetAllProjectSummariesAsync(CancellationToken cancellationToken = default);
    Task<ResponseDto<ProjectDto>> GetProjectByIdAsync(string id, CancellationToken cancellationToken = default);
}

public class ProjectService(IBaseDomainRepository<ProjectModel> projectRepository) : IProjectService
{
    private readonly IBaseDomainRepository<ProjectModel> _projectRepository = projectRepository;

    public async Task<ResponseDto<ProjectDto>> GetProjectByIdAsync(string id, CancellationToken cancellationToken = default)
    {
        var project = await _projectRepository.GetByIdAsync(id, cancellationToken);
        if (project is null)
        {
            return ResponseDto<ProjectDto>.FailureResult($"ProjectModel with ID '{id}' not found.")!;
        }

        return ResponseDto<ProjectDto>.SuccessResult(project.ToDto())!;
    }

    public async Task<ResponseDto<List<ProjectSummaryDto>>> GetAllProjectSummariesAsync(CancellationToken cancellationToken = default)
    {
        var projects = await _projectRepository.GetAllPublishedAsync(cancellationToken);
        var projectSummaryDtos = projects.Select(p => p.ToSummaryDto()).ToList();
        return ResponseDto<List<ProjectSummaryDto>>.SuccessResult(projectSummaryDtos)!;
    }
}