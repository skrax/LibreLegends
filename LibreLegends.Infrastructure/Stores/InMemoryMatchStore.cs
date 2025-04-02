using LibreLegends.Domain.Models.Matches;

namespace LibreLegends.Infrastructure.Stores;

public class InMemoryMatchStore : IMatchStore
{
    private readonly Dictionary<Guid, Match> _matches = [];

    public Task<IReadOnlyCollection<Match>> GetAsync(CancellationToken cancellationToken = default)
    {
        IReadOnlyCollection<Match> matches = _matches.Values.ToArray();

        return Task.FromResult(matches);
    }

    public Task<Match?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return _matches.TryGetValue(id, out var match)
            ? Task.FromResult<Match?>(match)
            : Task.FromResult<Match?>(null);
    }

    public Task<Guid> AddAsync(Match match, CancellationToken cancellationToken = default)
    {
        match.Id = Guid.NewGuid();
        
        _matches[match.Id] = match;
        
        return Task.FromResult(match.Id);
    }

    public Task<bool> UpdateAsync(Match match, CancellationToken cancellationToken = default)
    {
        if (!_matches.ContainsKey(match.Id))
        {
            return Task.FromResult(false);
        }

        _matches[match.Id] = match;
        
        return Task.FromResult(true);
    }

    public Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Task.FromResult(_matches.Remove(id));
    }

    public Task DeleteAsync(CancellationToken cancellationToken = default)
    {
        _matches.Clear();
        return Task.CompletedTask;
    }
}