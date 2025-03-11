namespace LibreLegends.Domain;

public class Spell : Card
{
    public required string Description { get; set; }

    public int Cost { get; set; }

    public required SpellAbilities? Abilities { get; set; }
}