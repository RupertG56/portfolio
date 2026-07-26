using Portfolio.Contracts.Common;
using Portfolio.Contracts.Site;

namespace Portfolio.AdminApp.Api;

public interface IPortfolioApiClient
{
    Task<ResponseDto<SiteDto?>> GetSiteAsync(
        CancellationToken cancellationToken = default);

    Task<ResponseDto> UpdateSiteAsync(
        SiteDto site,
        CancellationToken cancellationToken = default);
}
