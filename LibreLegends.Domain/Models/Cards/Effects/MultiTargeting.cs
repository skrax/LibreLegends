﻿namespace LibreLegends.Domain.Models.Cards.Effects;

public class MultiTargeting : Targeting
{
    public int? MinTargetCount { get; set; }
    
    public required int MaxTargetCount { get; set; }
}