using Portfolio.Api.Common;

namespace Portfolio.Api.Project;

public record ProjectDto(
    string Id,
    string Title,
    string Summary,
    string DescriptionMarkdown,
    IReadOnlyList<TechnologyDto> Technologies,
    ProjectLinksDto Links,
    IReadOnlyList<ProjectImageDto> Images,
    int SortOrder
);

public record ProjectSummaryDto(
    string Id,
    string Title,
    string Summary,
    int SortOrder
);

public record TechnologyDto(
    string Name,
    string? Url,
    string? Icon
);

public record ProjectLinksDto(
    string? Demo,
    string? GitHub,
    string? Documentation
);

public record ProjectImageDto(
    string Url,
    string AltText,
    int SortOrder
);