using Portfolio.Api.Common;
using Portfolio.Domain.Project;

namespace Portfolio.Api.Project;

public interface IProjectService
{
    Task<ResponseDto<List<ProjectSummaryDto>>> GetAllProjectSummariesAsync();
    Task<ResponseDto<ProjectDto>> GetProjectByIdAsync(string id);
}

public class ProjectService(IBaseDomainRepository<ProjectModel> projectRepository) : IProjectService
{
    private readonly IBaseDomainRepository<ProjectModel> _projectRepository = projectRepository;

    public async Task<ResponseDto<ProjectDto>> GetProjectByIdAsync(string id)
    {
        var project = await _projectRepository.GetByIdAsync(id);
        if (project is null)
        {
            return ResponseDto<ProjectDto>.FailureResult($"ProjectModel with ID '{id}' not found.");
        }

        return ResponseDto<ProjectDto>.SuccessResult(project.ToDto());
    }

    public async Task<ResponseDto<List<ProjectSummaryDto>>> GetAllProjectSummariesAsync()
    {
        var projects = await _projectRepository.GetAllPublishedAsync();
        var projectSummaryDtos = projects.Select(p => p.ToSummaryDto()).ToList();
        return ResponseDto<List<ProjectSummaryDto>>.SuccessResult(projectSummaryDtos);
    }
}