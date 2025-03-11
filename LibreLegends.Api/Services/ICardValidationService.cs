using LibreLegends.Domain;

namespace LibreLegends.Api.Services;

public interface ICardValidationService
{
    (bool IsValid, string? ErrorMessage) ValidateCard(Card card);
}