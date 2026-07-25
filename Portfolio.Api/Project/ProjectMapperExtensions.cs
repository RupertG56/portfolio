using Portfolio.Domain.Project;
using Portfolio.Contracts.Project;

namespace Portfolio.Api.Project;

public static class ProjectMapperExtensions
{
    public static ProjectModel ToDomain(this ProjectDocument document)
    {
        return new ProjectModel
        {
            Id = document.Id,
            Title = document.Title,
            DescriptionMarkdown = document.DescriptionMarkdown,
            Images = document.Images,
            Links = document.Links,
            Summary = document.Summary,
            Technologies = document.Technologies,
            Featured = document.Featured,
            SortOrder = document.SortOrder,
            IsPublished = document.IsPublished,
            IsDeleted = document.IsDeleted,
            CompletedOn = document.CompletedOn
        };
    }

    public static ProjectDocument ToDocument(this ProjectModel domain)
    {
        return new ProjectDocument
        {
            Id = domain.Id,
            Title = domain.Title,
            DescriptionMarkdown = domain.DescriptionMarkdown,
            Images = domain.Images,
            Links = domain.Links,
            Summary = domain.Summary,
            Technologies = domain.Technologies,
            Featured = domain.Featured,
            SortOrder = domain.SortOrder,
            IsPublished = domain.IsPublished,
            IsDeleted = domain.IsDeleted,
            CompletedOn = domain.CompletedOn
        };
    }

    public static ProjectDto ToDto(this ProjectModel domain)
    {
        return new ProjectDto(
            domain.Id,
            domain.Title,
            domain.Summary,
            domain.DescriptionMarkdown,
            [.. domain.Technologies.Select(t => new TechnologyDto(t.Name, t.Url, t.Icon))],
            new ProjectLinksDto(domain.Links.Demo, domain.Links.GitHub, domain.Links.Documentation),
            [.. domain.Images.Select(i => new ProjectImageDto(i.Url, i.AltText, i.SortOrder))],
            domain.SortOrder
        );
    }

    public static ProjectSummaryDto ToSummaryDto(this ProjectModel domain)
    {
        return new ProjectSummaryDto(
            domain.Id,
            domain.Title,
            domain.Summary,
            domain.SortOrder
        );
    }
}