using Portfolio.Domain.Site;
namespace Portfolio.Api.Site;

public interface ISiteRepository
{
    public Task<SiteModel?> GetAsync(CancellationToken cancellationToken = default);

    public Task<bool> UpdateAsync(SiteModel site,
        CancellationToken cancellationToken = default);
}
