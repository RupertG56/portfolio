

namespace Portfolio.Api.Project;

public static class ProjectEndpoints
{
    public static IEndpointRouteBuilder MapProjectEndpoints(this IEndpointRouteBuilder endpoints)
    {
        var projectGroup = endpoints.MapGroup("/api/projects")
            .WithTags("Projects");

        projectGroup.MapGet("/", GetAllProjectSummaries)
            .WithName("GetProjects");
        projectGroup.MapGet("/{id}", GetProjectById)
            .WithName("GetProjectById");
        //projectGroup.MapPost("/", CreateProject);
        //projectGroup.MapPut("/{id}", UpdateProject);
        //projectGroup.MapDelete("/{id}", DeleteProject);

        return endpoints;
    }

    private static async Task<IResult> GetAllProjectSummaries(IProjectService service)
    {
        var response = await service.GetAllProjectSummariesAsync();
        if (!response.Success)
        {
            return Results.BadRequest(response);
        }
        return Results.Ok(response);
    }

    private static async Task<IResult> GetProjectById(string id, IProjectService service)
    {
        var response = await service.GetProjectByIdAsync(id);
        if (!response.Success)
        {
            return Results.NotFound(response);
        }
        return Results.Ok(response);
    }
}