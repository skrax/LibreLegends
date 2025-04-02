namespace LibreLegends.MatchMaking.Exceptions;

public class MatchNotFoundException(Guid matchId) : Exception($"The match with id {matchId} was not found.");