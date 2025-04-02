using LibreLegends.Domain.Models.Matches;

namespace LibreLegends.Infrastructure.Stores;

public interface IMatchStore
{
    Task<IReadOnlyCollection<Match>> GetAsync(CancellationToken cancellationToken = default);
    
    Task<Match?> GetAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<Guid> AddAsync(Match match, CancellationToken cancellationToken = default);
    
    Task<bool> UpdateAsync(Match match, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task DeleteAsync(CancellationToken cancellationToken = default);
}