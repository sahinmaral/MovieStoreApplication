using FluentValidation;

namespace MovieStoreAppWebAPI.Operations.AuthOperation.RefreshToken
{
    public class TokenModelValidator : AbstractValidator<TokenModel>
    {
        public TokenModelValidator()
        {
            RuleFor(x => x.AccessToken).NotNull().WithMessage("Access token boş bırakılamaz");

            RuleFor(x => x.RefreshToken).NotNull().WithMessage("Refresh token boş bırakılamaz");
        }
    }
}
