namespace LibreLegends.Infrastructure.Domain;

public class AoeTargeting : Targeting
{
    public bool? FriendlyOnly { get; set; }
    
    public bool? EnemyOnly { get; set; }
    
    public bool? HeroOnly { get; set; }
}