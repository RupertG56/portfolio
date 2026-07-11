using Portfolio.Api.Common;

namespace Portfolio.Api.Project;

public static class ProjectMapperExtensions
{
    public static Project ToDomain(this ProjectDocument document)
    {
        return new Project
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

    public static ProjectDocument ToDocument(this Project domain)
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
}