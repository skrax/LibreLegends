﻿namespace LibreLegends.Infrastructure.Schema;

internal class CardTableRecord
{
    public required Guid id { get; set; }
    
    public required string name { get; set; }
    
    public string? description { get; set; }
    
    public int card_type_id { get; set; }
    
    public int? cost { get; set; }
    
    public int? health { get; set; }
    
    public int? strength { get; set; }
    
    public string? abilities { get; set; }
}