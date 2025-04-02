using LibreLegends.MatchMaking.Models.Request;
using LibreLegends.MatchMaking.Models.Response;

namespace LibreLegends.MatchMaking.Services;

public interface IMatchMakingService
{
    Task<IReadOnlyCollection<MatchResponse>> GetMatchesAsync(CancellationToken cancellationToken = default);
    
    Task<MatchResponse?> GetMatchByIdAsync(Guid id, CancellationToken cancellationToken = default);

    Task<MatchResponse> CreateAsync(CreateMatchRequest request, CancellationToken cancellationToken = default);
    
    Task<MatchResponse> JoinMatchAsync(JoinMatchRequest request, CancellationToken cancellationToken = default);
    
    Task LeaveMatchAsync(LeaveMatchRequest request, CancellationToken cancellationToken = default);
}