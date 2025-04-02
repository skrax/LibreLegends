using LibreLegends.Api.Models.Request;
using LibreLegends.Api.Models.Response;
using LibreLegends.CardManagement.Application.Models.Request;
using LibreLegends.CardManagement.Application.Models.Response;

namespace LibreLegends.Api.Mapper;

public static class CardDtoMapper
{
    public static CardDto AsCardTo(this CardResponse cardResponse)
    {
        return cardResponse switch
        {
            CreatureResponse creatureResponse => creatureResponse.AsCreatureDto(),
            SpellResponse spellResponse => spellResponse.AsSpellDto(),
            _ => throw new ArgumentOutOfRangeException(nameof(cardResponse))
        };
    }

    public static CreatureDto AsCreatureDto(this CreatureResponse creatureResponse) => new()
    {
        Id = creatureResponse.Id,
        Name = creatureResponse.Name,
        FlavorText = creatureResponse.FlavorText,
        Description = creatureResponse.Description,
        Cost = creatureResponse.Cost,
        Strength = creatureResponse.Strength,
        Health = creatureResponse.Health,
        Defender = creatureResponse.Defender,
        Haste = creatureResponse.Haste,
        Exposed = creatureResponse.Exposed,
        BehaviorJson = creatureResponse.BehaviorJson,
    };

    public static SpellDto AsSpellDto(this SpellResponse spellResponse) => new()
    {
        Id = spellResponse.Id,
        Name = spellResponse.Name,
        FlavorText = spellResponse.FlavorText,  
        Description = spellResponse.Description,
        Cost = spellResponse.Cost,
        BehaviorJson = spellResponse.BehaviorJson,
    };

    public static CreateCreatureRequest AsCreateCreatureRequest(this CreateOrUpdateCreatureDto dto) => new()
    {
        Name = dto.Name,
        FlavorText = dto.FlavorText,
        Description = dto.Description,
        Cost = dto.Cost,
        Health = dto.Health,
        Strength = dto.Strength,
        BehaviorJson = dto.BehaviorJson
    };

    public static UpdateCreatureRequest AsUpdateCreatureRequest(this CreateOrUpdateCreatureDto dto, Guid id) => new()
    {
        Id = id,
        Name = dto.Name,
        FlavorText = dto.FlavorText,
        Description = dto.Description,
        Cost = dto.Cost,
        Health = dto.Health,
        Strength = dto.Strength,
        BehaviorJson = dto.BehaviorJson
    };

    public static CreateSpellRequest AsCreateSpellRequest(this CreateOrUpdateSpellDto dto) => new()
    {
        Name = dto.Name,
        FlavorText = dto.FlavorText,
        Description = dto.Description,
        Cost = dto.Cost,
        BehaviorJson = dto.BehaviorJson
    };

    public static UpdateSpellRequest AsUpdateSpellRequest(this CreateOrUpdateSpellDto dto, Guid id) => new()
    {
        Id = id,
        Name = dto.Name,
        FlavorText = dto.FlavorText,
        Description = dto.Description,
        Cost = dto.Cost,
        BehaviorJson = dto.BehaviorJson
    };
}