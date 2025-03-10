using LibreLegends.Infrastructure.Domain;

namespace LibreLegends.Infrastructure.Repositories;

public interface ICardRepository
{
    /// <summary>
    /// Query all cards from the database
    /// </summary>
    Task<IReadOnlyList<Card>> GetAsync();
    
    /// <summary>
    /// Query a cards by ID
    /// </summary>
    Task<Card?> GetAsync(Guid id);
    
    /// <summary>
    /// Query cards by card type
    /// </summary>
    Task<IReadOnlyList<Card>> GetAsync(CardType cardType);
    
    /// <summary>
    /// Insert a card into the database
    /// </summary>
    Task<Guid> AddAsync(Card card);
    
    /// <summary>
    /// Update a card in the database
    /// </summary>
    Task<bool> UpdateAsync(Card card);
    
    /// <summary>
    /// Delete a card from the database
    /// </summary>
    Task<bool> DeleteAsync(Guid id);
    
    /// <summary>
    /// Delete all cards from the database
    /// </summary>
    Task DeleteAsync();
}