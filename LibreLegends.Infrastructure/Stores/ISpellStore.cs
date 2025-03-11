using LibreLegends.Domain;

namespace LibreLegends.Infrastructure.Stores;

public interface ISpellStore
{
    Task<Guid> AddAsync(Spell spell, CancellationToken cancellationToken = default);

    Task<bool> UpdateAsync(Spell spell, CancellationToken cancellationToken = default);
}