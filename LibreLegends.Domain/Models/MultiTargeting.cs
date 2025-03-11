namespace LibreLegends.Domain.Models;

public class MultiTargeting : Targeting
{
    public int? MinTargetCount { get; set; }
    
    public required int MaxTargetCount { get; set; }
}