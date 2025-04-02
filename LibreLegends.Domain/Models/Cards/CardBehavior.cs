using System.Text.Json;
using LibreLegends.Domain.Exceptions;

namespace LibreLegends.Domain.Models.Cards;

public abstract class CardBehavior
{
    public static CardBehavior FromJson(string json, JsonSerializerOptions? opt = null)
    {
        CardBehavior? behavior;
        
        try
        {
            behavior = JsonSerializer.Deserialize<CardBehavior>(json, opt);
        }
        catch (Exception)
        {
            throw new InvalidBehaviorJsonException();
        }

        if (behavior is null)
        {
            throw new InvalidBehaviorJsonException();
        }

        return behavior;
    }

    public string ToJson(JsonSerializerOptions? opt = null)
    {
        return JsonSerializer.Serialize(this, opt);
    }
}
