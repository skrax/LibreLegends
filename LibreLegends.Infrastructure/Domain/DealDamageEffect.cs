namespace LibreLegends.Infrastructure.Domain;

public class DealDamageEffect : Effect
{
    public required int DamageAmount { get; set; }
    
    public required Targeting Targeting { get; set; }
}