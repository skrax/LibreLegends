namespace LibreLegends.Infrastructure.Schema;

internal class CardTypeTableRecord
{
    public required int id { get; set; }
    
    public required string name { get; set; }
    
    public string? description { get; set; }
}