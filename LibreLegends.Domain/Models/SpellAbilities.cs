namespace LibreLegends.Domain.Models;

public class SpellAbilities : Abilities
{
    public List<Effect> OnPlay { get; set; } = [];
}