﻿namespace LibreLegends.CardManagement.Models.Request;

public class UpdateSpellRequest
{
    public required Guid Id { get; set; }
    
    public string? FlavorText { get; set; }

    public required string Name { get; set; }

    public required string Description { get; set; }

    public required int Cost { get; set; }

    public required string BehaviorJson { get; set; }
}