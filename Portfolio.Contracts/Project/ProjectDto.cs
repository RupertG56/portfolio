using System;
using System.Collections.Generic;
using System.Text;

namespace Portfolio.Contracts.Project;

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
