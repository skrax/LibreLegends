namespace LibreLegends.Game;

public class Match
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public List<Guid> UserIds { get; init; } = [];

    public Dictionary<Guid, Deck> DeckByUserId { get; init; } = [];
}

public class MatchService
{
    private readonly Dictionary<Guid, Match> _matches = [];

    public Match Create(List<Guid> userIds, Dictionary<Guid, Deck> deckByUserId)
    {
        var match = new Match();

        _matches[match.Id] = match;

        return match;
    }

    public Match Create(Lobby lobby) => Create(lobby.UserIds, lobby.DecksByUserId);
    

    public Match? Get(Guid id)
    {
        return _matches.GetValueOrDefault(id);
    }

    public List<Match> Get()
    {
        return _matches.Values.ToList();
    }

    public void Delete(Guid id)
    {
        _matches.Remove(id);
    }
}