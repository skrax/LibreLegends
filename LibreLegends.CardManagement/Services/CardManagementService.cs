using LibreLegends.CardManagement.Mapper;
using LibreLegends.CardManagement.Exceptions;
using LibreLegends.CardManagement.Models.Request;
using LibreLegends.CardManagement.Models.Response;
using LibreLegends.Domain.Exceptions;
using LibreLegends.Domain.Models;
using LibreLegends.Domain.Models.Cards;
using LibreLegends.Infrastructure.Stores;

namespace LibreLegends.CardManagement.Services;

public class CardManagementService(ICardStore store) : ICardManagementService
{
    public async Task<IReadOnlyCollection<CardResponse>> GetCardsAsync(CancellationToken cancellationToken = default)
    {
        var cards = await store.GetAsync(cancellationToken);

        return cards
            .Select(x => x.AsCardResponse())
            .ToArray();
    }

    public async Task<IReadOnlyCollection<CardResponse>> GetCardsByTypeAsync(CardType cardType,
        CancellationToken cancellationToken = default)
    {
        var cards = await store.GetAsync(cardType, cancellationToken);

        return cards
            .Select(x => x.AsCardResponse())
            .ToArray();
    }

    public async Task<CardResponse?> GetCardByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var card = await store.GetAsync(id, cancellationToken);

        return card?.AsCardResponse();
    }

    public async Task<CreatureResponse> CreateCreatureAsync(CreateCreatureRequest request,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var creature = request.AsCreature();

            await store.AddAsync(creature, cancellationToken);

            return creature.AsCreatureResponse();
        }
        catch (DomainModelException modelException)
        {
            throw new CardManagementValidationException(modelException.Message, modelException);
        }
    }

    public async Task<SpellResponse> CreateSpellAsync(CreateSpellRequest request,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var spell = request.AsSpell();

            await store.AddAsync(spell, cancellationToken);

            return spell.AsSpellResponse();
        }
        catch (DomainModelException modelException)
        {
            throw new CardManagementValidationException(modelException.Message, modelException);
        }
    }

    public async Task<CreatureResponse?> UpdateCreatureAsync(UpdateCreatureRequest request,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var creature = request.AsCreature();

            var success = await store.UpdateAsync(creature, cancellationToken);

            return success ? creature.AsCreatureResponse() : null;
        }
        catch (DomainModelException modelException)
        {
            throw new CardManagementValidationException(modelException.Message, modelException);
        }
    }

    public async Task<SpellResponse?> UpdateSpellAsync(UpdateSpellRequest request,
        CancellationToken cancellationToken = default)
    {
        try
        {
            var spell = request.AsSpell();

            var success = await store.UpdateAsync(spell, cancellationToken);

            return success ? spell.AsSpellResponse() : null;
        }
        catch (DomainModelException modelException)
        {
            throw new CardManagementValidationException(modelException.Message, modelException);
        }
    }

    public async Task<bool> DeleteByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await store.DeleteAsync(id, cancellationToken);
    }

    public async Task DeleteAllCardsAsync(CancellationToken cancellationToken = default)
    {
        await store.DeleteAsync(cancellationToken);
    }
}