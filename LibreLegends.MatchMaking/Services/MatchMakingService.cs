using LibreLegends.Domain.Models.Matches;
using LibreLegends.Infrastructure.Stores;
using LibreLegends.MatchMaking.Exceptions;
using LibreLegends.MatchMaking.Mapper;
using LibreLegends.MatchMaking.Models.Request;
using LibreLegends.MatchMaking.Models.Response;

namespace LibreLegends.MatchMaking.Services;

public class MatchMakingService(IMatchStore matchStore) : IMatchMakingService
{
    public async Task<IReadOnlyCollection<MatchResponse>> GetMatchesAsync(CancellationToken cancellationToken = default)
    {
        var matches = await matchStore.GetAsync(cancellationToken);

        var response = matches.Select(x => x.AsMatchResponse()).ToArray();
        
        return response;
    }

    public async Task<MatchResponse?> GetMatchByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var match = await matchStore.GetAsync(id, cancellationToken);

        var response = match?.AsMatchResponse();

        return response;
    }

    public Task<MatchResponse> CreateAsync(CreateMatchRequest request, CancellationToken cancellationToken = default)
    {
        var match = new Match
        {
            Id = Guid.NewGuid(),
            Name = request.Name
        };

        var hostPlayer = match.AddPlayer(request.PlayerName);

        matchStore.AddAsync(match, cancellationToken);

        var response = match.AsMatchResponse();
        
        response.PlayerToken = hostPlayer.Token;

        return Task.FromResult(response);
    }

    public async Task<MatchResponse> JoinMatchAsync(JoinMatchRequest request, CancellationToken cancellationToken = default)
    {
        var match = await matchStore.GetAsync(request.MatchId, cancellationToken);
        
        if (match is null)
        {
            throw new MatchNotFoundException(request.MatchId);
        }

        var player = match.AddPlayer(request.PlayerName);
        
        await matchStore.UpdateAsync(match, cancellationToken);

        var response = match.AsMatchResponse();
        response.PlayerToken = player.Token;

        return response;
    }

    public async Task LeaveMatchAsync(LeaveMatchRequest request, CancellationToken cancellationToken = default)
    {
        var match = await matchStore.GetAsync(request.MatchId, cancellationToken);
        
        if (match is null)
        {
            throw new MatchNotFoundException(request.MatchId);
        }
        
        match.RemovePlayer(request.PlayerToken);

        if (!match.HostPlayerId.HasValue)
        {
            await matchStore.DeleteAsync(match.Id, cancellationToken);
        }
        else
        {
            await matchStore.UpdateAsync(match, cancellationToken);
        }
    }
}