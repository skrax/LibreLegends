namespace LibreLegends.Domain.Exceptions;

public class EmptyOrWhiteSpaceException(string propertyName) : DomainModelException($"{propertyName} cannot be empty or contain only whitespace");