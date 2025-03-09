namespace LibreLegends.Infrastructure.Domain;

public class SpellAbilities : Abilities
{
    public List<Effect> on_play { get; set; } = [];
}