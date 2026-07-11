namespace Portfolio.Api.Common;

public interface IBaseDomainRepository<TDomain> : IRepository<TDomain>
    where TDomain : BaseDomain
{
    Task<IReadOnlyList<TDomain>> GetPublishedAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TDomain>> GetAllPublishedAsync(CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TDomain>> GetAllDeletedAsync(CancellationToken cancellationToken = default);
}