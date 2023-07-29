using FluentValidation;

namespace MovieStoreAppWebAPI.Operations.AuthOperation.Login
{
    public class UserLoginViewModelValidator : AbstractValidator<UserLoginViewModel>
    {
        public UserLoginViewModelValidator()
        {
            RuleFor(x => x.Username).NotNull().WithMessage("Kullanıcı adı , boş bırakılamaz");

            RuleFor(x => x.Password).NotNull().WithMessage("Şifre , boş bırakılamaz");
        }
    }
}
