using MongoDB.Driver;
using Portfolio.Api.Common;
using Portfolio.Api.Context;

namespace Portfolio.Api.Project;

public class ProjectRepository(IPortfolioContext context)
    : IBaseDomainRepository<Project>
{
    private readonly IPortfolioContext _context = context;

    public async Task<IReadOnlyList<Project>> GetPublishedAsync(
        CancellationToken cancellationToken = default)
    {
        var projects = await _context.Projects
            .Find(doc => doc.IsPublished && !doc.IsDeleted)
            .SortBy(p => p.SortOrder)
            .ToListAsync(cancellationToken);
        return [.. projects.Select(p => p.ToDomain())];
    }

    public async Task<IReadOnlyList<Project>> GetAllPublishedAsync(
        CancellationToken cancellationToken = default)
    {
        var projects = await _context.Projects
            .Find(doc => doc.IsPublished)
            .SortBy(p => p.SortOrder)
            .ToListAsync(cancellationToken);
        return [.. projects.Select(p => p.ToDomain())];
    }

    public async Task<IReadOnlyList<Project>> GetAllDeletedAsync(
        CancellationToken cancellationToken = default)
    {
        var projects = await _context.Projects
            .Find(doc => doc.IsDeleted)
            .SortBy(p => p.SortOrder)
            .ToListAsync(cancellationToken);
        return [.. projects.Select(p => p.ToDomain())];
    }

    public async Task<Project?> GetByIdAsync(string id,
        CancellationToken cancellationToken = default)
    {
        var doc = await _context.Projects
            .Find(doc => doc.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
        return doc?.ToDomain();
    }

    public async Task<IReadOnlyList<Project>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        return await _context.Projects
            .Find(FilterDefinition<ProjectDocument>.Empty)
            .SortBy(p => p.SortOrder)
            .Project(p => p.ToDomain())
            .ToListAsync(cancellationToken);
    }

    public async Task<bool> CreateAsync(Project project, CancellationToken cancellationToken = default)
    {
        var doc = project.ToDocument();
        doc.CreatedAt = DateTime.UtcNow;
        await _context.Projects.InsertOneAsync(doc,
            cancellationToken: cancellationToken);
        return true;
    }

    public async Task<bool> UpdateAsync(string id, Project project,
        CancellationToken cancellationToken = default)
    {
        var doc = project.ToDocument();
        var existingDoc = await LocateDocumentByIdAsync(
            id, cancellationToken);
        if (existingDoc == null)
            return false;

        await _context.Projects.ReplaceOneAsync(d => d.Id == id,
            doc, cancellationToken: cancellationToken);
        return true;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default)
    {
        var existingDoc = await LocateDocumentByIdAsync(id, cancellationToken);
        if (existingDoc == null)
            return false;
        existingDoc.IsDeleted = true;
        await _context.Projects.ReplaceOneAsync(d => d.Id == id,
            existingDoc, cancellationToken: cancellationToken);
        return true;
    }

    private async Task<ProjectDocument> LocateDocumentByIdAsync(string id, CancellationToken cancellationToken)
    {
        return await _context.Projects
            .Find(doc => doc.Id == id)
            .FirstOrDefaultAsync(cancellationToken);
    }
}