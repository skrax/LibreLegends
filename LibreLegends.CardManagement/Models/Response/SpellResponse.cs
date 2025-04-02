namespace LibreLegends.CardManagement.Models.Response;

public class SpellResponse : CardResponse
{
    public required string Description { get; set; }

    public required int Cost { get; set; }

    public required string BehaviorJson { get; set; }
}