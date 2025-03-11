namespace LibreLegends.Domain.Exceptions;

public class NegativeStatException(string propertyName) : DomainModelException($"{propertyName} cannot be negative");