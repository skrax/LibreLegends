namespace LibreLegends.Domain.Models;

public class DealDamageEffect : Effect
{
    public required int DamageAmount { get; set; }
    
    public required Targeting Targeting { get; set; }
}