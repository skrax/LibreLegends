namespace LibreLegends.Api.Models.Response;

public class CreatureDto : CardDto
{
    public required string? Description { get; set; }

    public required int Cost { get; set; }

    public required int Strength { get; set; }

    public required int Health { get; set; }

    public string? AbilitiesJson { get; set; }
}