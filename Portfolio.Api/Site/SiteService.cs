using Portfolio.Contracts.Site;
using Portfolio.Domain.Site;

namespace Portfolio.Api.Site;

public class SiteService(ISiteRepository repository)
    : ISiteService
{
    private readonly ISiteRepository _repository = repository;

    public async Task<SiteDto?> GetAsync(CancellationToken cancellationToken = default)
    {
        var model = await _repository.GetAsync(cancellationToken);
        return model?.ToDto();
    }

    public async Task<bool> UpdateAsync(SiteDto site,
        CancellationToken cancellationToken = default)
    {
        var model = site.ToDomain();
        return await _repository.UpdateAsync(model, cancellationToken);
    }
}