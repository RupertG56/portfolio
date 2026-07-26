using Portfolio.Contracts.Common;
using Portfolio.Contracts.Site;

namespace Portfolio.Api.Site;

public interface ISiteService
{
    public Task<ResponseDto<SiteDto?>> GetAsync(CancellationToken cancellationToken = default);

    public Task<ResponseDto> UpdateAsync(SiteDto site,
        CancellationToken cancellationToken = default);
}