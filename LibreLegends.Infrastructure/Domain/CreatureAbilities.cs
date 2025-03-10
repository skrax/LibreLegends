namespace LibreLegends.Infrastructure.Domain;

public class CreatureAbilities : Abilities
{
    public bool? Defender { get; set; }

    public bool? Haste { get; set; }

    public bool? Exposed { get; set; }

    public List<Effect> OnPlay { get; set; } = [];

    public List<Effect> Aura { get; set; } = [];
}