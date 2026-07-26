using Portfolio.AdminApp.Api;
using Portfolio.Contracts.Common;
using Portfolio.Contracts.Site;

namespace Portfolio.AdminApp.Services;

public interface ISiteService
{
    Task<ResponseDto<SiteDto?>> GetAsync(
        CancellationToken cancellationToken = default);

    Task<ResponseDto> UpdateAsync(
        SiteDto site,
        CancellationToken cancellationToken = default);
}

public sealed class SiteService(IPortfolioApiClient apiClient)
    : ISiteService
{
    public Task<ResponseDto<SiteDto?>> GetAsync(
        CancellationToken cancellationToken = default) =>
        apiClient.GetSiteAsync(cancellationToken);

    public Task<ResponseDto> UpdateAsync(
        SiteDto site,
        CancellationToken cancellationToken = default) =>
        apiClient.UpdateSiteAsync(site, cancellationToken);
}
