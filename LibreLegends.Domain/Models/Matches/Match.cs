namespace LibreLegends.Domain.Models.Matches;

public class Match
{
    public Guid Id { get; set; }

    public required string Name { get; init; }

    public Guid? HostPlayerId { get; private set; }

    private readonly List<MatchedPlayer> _players = [];

    public IReadOnlyCollection<MatchedPlayer> Players => _players;

    public MatchedPlayer AddPlayer(string playerName)
    {
        var player = new MatchedPlayer
        {
            Id = Guid.NewGuid(),
            Name = playerName,
            Token = Guid.NewGuid(),
        };

        if (_players.Count is 0)
        {
            HostPlayerId = player.Id;
        }

        _players.Add(player);

        return player;
    }

    public void RemovePlayer(Guid playerToken)
    {
        var player = _players.FirstOrDefault(x => x.Token == playerToken);

        if (player is null)
        {
            return;
        }

        _players.Remove(player);

        if (_players.Count is 0)
        {
            HostPlayerId = null;
            return;
        }

        if (player.Id == HostPlayerId)
        {
            HostPlayerId = _players.First().Id;
        }
    }
}