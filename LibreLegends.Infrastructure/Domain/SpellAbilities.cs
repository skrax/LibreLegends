namespace LibreLegends.Infrastructure.Domain;

public class SpellAbilities : Abilities
{
    public List<Effect> OnPlay { get; set; } = [];
}