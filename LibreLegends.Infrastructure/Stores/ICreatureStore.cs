using LibreLegends.Domain;

namespace LibreLegends.Infrastructure.Stores;

public interface ICreatureStore
{
    Task<Guid> AddAsync(Creature creature, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(Creature creature, CancellationToken cancellationToken = default);
}