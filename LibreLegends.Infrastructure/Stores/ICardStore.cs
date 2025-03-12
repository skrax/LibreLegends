using LibreLegends.Domain.Models;
using LibreLegends.Domain.Models.Cards;

namespace LibreLegends.Infrastructure.Stores;

public interface ICardStore
{
    /// <summary>
    /// Query all cards from the database
    /// </summary>
    Task<IReadOnlyList<Card>> GetAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Query a cards by ID
    /// </summary>
    Task<Card?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Query cards by card type
    /// </summary>
    Task<IReadOnlyList<Card>> GetAsync(CardType cardType, CancellationToken cancellationToken = default);

    /// <summary>
    /// Insert a card into the database
    /// </summary>
    Task<Guid> AddAsync(Card card, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update a card in the database
    /// </summary>
    Task<bool> UpdateAsync(Card card, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete a card from the database
    /// </summary>
    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete all cards from the database
    /// </summary>
    Task DeleteAsync(CancellationToken cancellationToken = default);
}