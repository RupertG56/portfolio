using System.Net.Http;
using System.Net.Http.Json;
using Portfolio.Contracts.Common;
using Portfolio.Contracts.Site;

namespace Portfolio.AdminApp.Api;

public sealed class PortfolioApiClient(HttpClient httpClient)
    : IPortfolioApiClient
{
    public async Task<ResponseDto<SiteDto?>> GetSiteAsync(
        CancellationToken cancellationToken = default)
    {
        using var response = await httpClient.GetAsync(
            "api/site/",
            cancellationToken);

        return await ReadResponseAsync<ResponseDto<SiteDto?>>(
            response,
            cancellationToken);
    }

    public async Task<ResponseDto> UpdateSiteAsync(
        SiteDto site,
        CancellationToken cancellationToken = default)
    {
        using var response = await httpClient.PutAsJsonAsync(
            "api/site/",
            site,
            cancellationToken);

        return await ReadResponseAsync<ResponseDto>(
            response,
            cancellationToken);
    }

    private static async Task<T> ReadResponseAsync<T>(
        HttpResponseMessage response,
        CancellationToken cancellationToken)
    {
        var result = await response.Content.ReadFromJsonAsync<T>(
            cancellationToken);

        return result ?? throw new HttpRequestException(
            $"The API returned an empty or invalid response with status " +
            $"{(int)response.StatusCode} ({response.ReasonPhrase}).");
    }
}
