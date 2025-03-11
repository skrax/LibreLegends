namespace LibreLegends.Domain;

public class SpellAbilities : Abilities
{
    public List<Effect> OnPlay { get; set; } = [];
}