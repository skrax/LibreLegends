using LibreLegends.Infrastructure.Domain;

namespace LibreLegends.Infrastructure.Repositories;

public interface ICardRepository
{
    public Task<IReadOnlyList<Card>> GetCards();
}