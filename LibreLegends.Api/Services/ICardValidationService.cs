using LibreLegends.Infrastructure.Domain;

namespace LibreLegends.Api.Services;

public interface ICardValidationService
{
    (bool IsValid, string? ErrorMessage) ValidateCard(Card card);
}