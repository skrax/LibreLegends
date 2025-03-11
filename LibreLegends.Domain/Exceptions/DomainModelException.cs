namespace LibreLegends.Domain.Exceptions;

public abstract class DomainModelException : Exception
{
    protected DomainModelException()
    {
    }

    protected DomainModelException(string message) : base(message)
    {
    }

    protected DomainModelException(string message, Exception innerException) : base(message, innerException)
    {
    }
}