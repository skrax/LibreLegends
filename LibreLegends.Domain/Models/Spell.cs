using System.Text.Json;
using LibreLegends.Domain.Exceptions;

namespace LibreLegends.Domain.Models;

public class Spell : Card
{
    private int _cost;
    private string _description;

    public required string Description
    {
        get => _description;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new EmptyOrWhiteSpaceException(nameof(Description));
            }

            _description = value;
        }
    }

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

    public static SpellAbilities GetAbilitiesFromJson(string json, JsonSerializerOptions? opt = null)
    {
        SpellAbilities? abilities;
        
        try
        {
            abilities = JsonSerializer.Deserialize<SpellAbilities>(json, opt);
        }
        catch (Exception)
        {
            throw new InvalidAbilitiesJsonException();
        }

        if (abilities == null)
        {
            throw new InvalidAbilitiesJsonException();
        }

        return abilities;
    }

    public string GetAbilitiesAsJson(JsonSerializerOptions? opt = null)
    {
        return JsonSerializer.Serialize(Abilities, opt);
    }

    public void SetAbilitiesAsJson(string json, JsonSerializerOptions? opt = null)
    {
        Abilities = GetAbilitiesFromJson(json);
    }

    public required SpellAbilities? Abilities { get; set; }
}