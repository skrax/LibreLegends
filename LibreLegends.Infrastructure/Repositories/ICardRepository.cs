using LibreLegends.Infrastructure.Domain;

namespace LibreLegends.Infrastructure.Repositories;

public interface ICardRepository
{
    Task<IReadOnlyList<Card>> GetCards();
    Task<Card?> GetCardById(Guid id);
    Task<IReadOnlyList<Card>> GetCardsByType(CardType cardType);
    Task<Guid> CreateCard(Card card);
    Task<bool> UpdateCard(Card card);
    Task<bool> DeleteCard(Guid id);
    Task Delete();
}