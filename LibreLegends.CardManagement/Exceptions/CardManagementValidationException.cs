namespace LibreLegends.CardManagement.Exceptions;

public class CardManagementValidationException : Exception
{
    public CardManagementValidationException()
    {
    }

    public CardManagementValidationException(string message) : base(message)
    {
    }

    public CardManagementValidationException(string message, Exception inner) : base(message, inner)
    {
    }
}