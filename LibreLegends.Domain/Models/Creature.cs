using System.Text.Json;
using LibreLegends.Domain.Exceptions;

namespace LibreLegends.Domain.Models;

public class Creature : Card
{
    private int _cost;

    private int _strength;

    private int _health;
    public string? Description { get; set; }

    public required int Cost
    {
        get => _cost;

        set
        {
            if (value < 0)
            {
                throw new NegativeStatException(nameof(Cost));
            }

            _cost = value;
        }
    }

    public required int Strength
    {
        get => _strength;

        set
        {
            if (value < 0)
            {
                throw new NegativeStatException(nameof(Strength));
            }

            _strength = value;
        }
    }

    public required int Health
    {
        get => _health;

        set
        {
            if (value < 0)
            {
                throw new NegativeStatException(nameof(Health));
            }

            _health = value;
        }
    }

    public static CreatureAbilities GetAbilitiesFromJson(string json, JsonSerializerOptions? opt = null)
    {
        CreatureAbilities? abilities;
        try
        {
            abilities = JsonSerializer.Deserialize<CreatureAbilities>(json, opt);
        }
        catch (Exception)
        {
            throw new InvalidAbilitiesJsonException();
        }

        if (abilities is null)
        {
            throw new InvalidAbilitiesJsonException();
        }

        return abilities;
    }

    public string? GetAbilitiesAsJson(JsonSerializerOptions? opt = null)
    {
        return Abilities is null ? null : JsonSerializer.Serialize(Abilities, opt);
    }

    public void SetAbilitiesAsJson(string json, JsonSerializerOptions? opt = null)
    {
        Abilities = GetAbilitiesFromJson(json, opt);
    }

    public CreatureAbilities? Abilities { get; set; }
}