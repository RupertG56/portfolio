namespace Portfolio.Api.Common;

public interface IRepository<TDomain>
{
    Task<TDomain?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TDomain>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<bool> CreateAsync(TDomain domain, CancellationToken cancellationToken = default);
    Task<bool> UpdateAsync(string id, TDomain domain, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(string id, CancellationToken cancellationToken = default);
}