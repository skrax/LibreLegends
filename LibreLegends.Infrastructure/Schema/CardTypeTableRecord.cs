namespace LibreLegends.Infrastructure.Schema;

/// <summary>
/// C# representation of the table 'card_types'
/// </summary>
internal class CardTypeTableRecord
{
    public required int id { get; set; }
    
    public required string name { get; set; }
    
    public string? description { get; set; }
}