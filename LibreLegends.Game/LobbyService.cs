using System.Reflection.Metadata;
using Microsoft.Extensions.DependencyInjection;

namespace LibreLegends.Game;

public class Lobby
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public required string Description { get; init; }

    public List<Guid> UserIds { get; init; } = [];

    public Dictionary<Guid, Deck> DecksByUserId { get; init; } = [];
}

public class Deck
{
    public required string Name { get; init; }
}

public class LobbyService(UserService userService, MatchService matchService)
{
    private Dictionary<Guid, Lobby> Lobbies { get; init; } = [];

    public Lobby Create(string description)
    {
        var lobby = new Lobby
        {
            Description = description
        };

        Lobbies[lobby.Id] = lobby;

        return lobby;
    }

    public Lobby? Get(Guid id)
    {
        return Lobbies.GetValueOrDefault(id);
    }

    public List<Lobby> Get()
    {
        return Lobbies.Values.ToList();
    }

    public void AddUser(Guid lobbyId, Guid userId)
    {
        var lobby = Lobbies[lobbyId];

        var user = userService.Get(userId);

        if (user is null)
        {
            throw new InvalidOperationException("User not found");
        }

        if (lobby.UserIds.Contains(user.Id))
        {
            return;
        }

        lobby.UserIds.Add(user.Id);
    }

    public void SubmitDeck(Guid lobbyId, Guid userId, string deckName)
    {
        var lobby = Lobbies[lobbyId];

        var userFound = lobby.UserIds.Contains(userId);
        if (userFound is false)
        {
            throw new InvalidOperationException("User not found");
        }

        var deck = new Deck
        {
            Name = deckName
        };

        lobby.DecksByUserId[userId] = deck;
    }

    public void CreateMatch(Guid lobbyId)
    {
        var lobby = Lobbies[lobbyId];


        var match = matchService.Create(lobby.UserIds, lobby.DecksByUserId);
        
    }

    public void Delete(Guid id)
    {
        Lobbies.Remove(id);
    }
}