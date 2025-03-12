using LibreLegends.CardManagement.Application.Models.Request;
using LibreLegends.CardManagement.Application.Models.Response;
using LibreLegends.Domain.Models;
using LibreLegends.Domain.Models.Cards;

namespace LibreLegends.CardManagement.Application.Services;

public interface ICardManagementService
{
    Task<IReadOnlyCollection<CardResponse>> GetCardsAsync(
        CancellationToken cancellationToken = default
    );

    Task<IReadOnlyCollection<CardResponse>> GetCardsByTypeAsync(
        CardType cardType,
        CancellationToken cancellationToken = default
    );

    Task<CardResponse?> GetCardByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default
    );

    Task<CreatureResponse> CreateCreatureAsync(
        CreateCreatureRequest request,
        CancellationToken cancellationToken = default
    );

    Task<SpellResponse> CreateSpellAsync(
        CreateSpellRequest request,
        CancellationToken cancellationToken = default
    );

    Task<CreatureResponse?> UpdateCreatureAsync(
        UpdateCreatureRequest request,
        CancellationToken cancellationToken = default
    );

    Task<SpellResponse?> UpdateSpellAsync(
        UpdateSpellRequest request,
        CancellationToken cancellationToken = default
    );

    Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task DeleteAllCardsAsync(CancellationToken cancellationToken = default);
}