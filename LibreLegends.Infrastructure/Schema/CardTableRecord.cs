namespace LibreLegends.Infrastructure.Schema;

/// <summary>
/// C# representation of the table 'cards'
/// </summary>
internal class CardTableRecord
{
    public required Guid id { get; set; }
    
    public required string name { get; set; }
    
    public string? flavor_text { get; set; }
    
    public string? description { get; set; }
    
    public int card_type_id { get; set; }
    
    public int? cost { get; set; }
    
    public int? health { get; set; }
    
    public int? strength { get; set; }
    
    public bool? defender { get; set; }
    
    public bool? haste { get; set; }
    
    public bool? exposed { get; set; }
    
    public string? behavior { get; set; }
}