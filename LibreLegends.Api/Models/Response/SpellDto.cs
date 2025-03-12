﻿namespace LibreLegends.Api.Models.Response;

public class SpellDto : CardDto
{
    public required string Description { get; set; }

    public required int Cost { get; set; }

    public required string BehaviorJson { get; set; }
}