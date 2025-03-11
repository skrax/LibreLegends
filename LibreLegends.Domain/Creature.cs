namespace LibreLegends.Domain;

public class Creature : Card
{
    public string? Description { get; set; }

    public required int Cost { get; set; }

    public required int Strength { get; set; }

    public required int Health { get; set; }

    public CreatureAbilities? Abilities { get; set; }
}