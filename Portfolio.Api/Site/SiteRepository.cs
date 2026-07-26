using MongoDB.Driver;
using Portfolio.Domain.Site;
using Portfolio.Api.Context;

namespace Portfolio.Api.Site;

public class SiteRepository(IPortfolioContext context)
    : ISiteRepository
{
    private readonly IPortfolioContext _context = context;

    public async Task<SiteModel?> GetAsync(CancellationToken cancellationToken = default)
    {
        var doc = await _context.Site
            .Find(FilterDefinition<SiteDocument>.Empty)
            .FirstOrDefaultAsync(cancellationToken);
        return doc?.ToDomain();
    }

    public async Task<bool> UpdateAsync(SiteModel site,
        CancellationToken cancellationToken = default)
    {
        var doc = site.ToDocument();
        await _context.Site.ReplaceOneAsync(
            FilterDefinition<SiteDocument>.Empty, doc, cancellationToken: cancellationToken);
        return true;
    }
}