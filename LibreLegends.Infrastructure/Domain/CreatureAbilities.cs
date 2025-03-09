namespace LibreLegends.Infrastructure.Domain;

public class CreatureAbilities : Abilities
{
    public bool? defender { get; set; }

    public bool? haste { get; set; }

    public bool? exposed { get; set; }

    public List<Effect> on_play { get; set; } = [];

    public List<Effect> aura { get; set; } = [];
}