using Portfolio.Contracts.Site;
using Portfolio.Domain.Site;

namespace Portfolio.Api.Site;

public interface ISiteService
{
    public Task<ResponseDto<SiteDto?>> GetAsync(CancellationToken cancellationToken = default);

    public Task<bool> UpdateAsync(SiteDto site,
        CancellationToken cancellationToken = default);
}