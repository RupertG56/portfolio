
using Portfolio.Contracts.Site;
using Portfolio.Contracts.Common;

namespace Portfolio.Api.Site;

public class SiteService(ISiteRepository repository)
    : ISiteService
{
    private readonly ISiteRepository _repository = repository;

    public async Task<ResponseDto<SiteDto?>> GetAsync(CancellationToken cancellationToken = default)
    {
        var model = await _repository.GetAsync(cancellationToken);
        return model is null
            ? ResponseDto<SiteDto?>.FailureResult("Site not found.")
            : ResponseDto<SiteDto?>.SuccessResult(model.ToDto());
    }

    public async Task<ResponseDto> UpdateAsync(SiteDto site,
        CancellationToken cancellationToken = default)
    {
        var model = site.ToDomain();
        var result = await _repository.UpdateAsync(model, cancellationToken);
        return result
            ? ResponseDto.SuccessResult()
            : ResponseDto.FailureResult("Failed to update site.");
    }
}