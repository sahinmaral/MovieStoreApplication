using FluentValidation;

namespace MovieStoreAppWebAPI.Operations.UserOperation.Create
{
    public class CreateUserViewModelValidator : AbstractValidator<CreateUserViewModel>
    {
        public CreateUserViewModelValidator()
        {
            RuleFor(x => x.Username).NotNull().WithMessage("Kullanıcı adı , boş bırakılamaz");
            RuleFor(x => x.Username).MinimumLength(2).WithMessage("Kullanıcı adı , minimum 2 karakter olmalıdır");
            RuleFor(x => x.Username).MaximumLength(30).WithMessage("Kullanıcı adı , maksimum 30 karakter olmalıdır");

            RuleFor(x => x.Name).NotNull().WithMessage("İsim , boş bırakılamaz");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("İsim , minimum 2 karakter olmalıdır");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("İsim , maksimum 100 karakter olmalıdır");

            RuleFor(x => x.Surname).NotNull().WithMessage("Soyad , boş bırakılamaz");
            RuleFor(x => x.Surname).MinimumLength(2).WithMessage("Soyad , minimum 2 karakter olmalıdır");
            RuleFor(x => x.Surname).MaximumLength(100).WithMessage("Soyad , maksimum 100 karakter olmalıdır");

            RuleFor(x => x.Email).NotNull().WithMessage("Email , boş bırakılamaz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email , geçerli olmalıdır");
            RuleFor(x => x.Email).MinimumLength(10).WithMessage("Email , minimum 10 karakter olmalıdır");
            RuleFor(x => x.Email).MaximumLength(100).WithMessage("Email , maksimum 100 karakter olmalıdır");

            RuleFor(x => x.Password).NotNull().WithMessage("Şifre , boş bırakılamaz");
            RuleFor(x => x.Password)
                .Matches(@"^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,}$\r\n")
                .WithMessage("Password must contain: At least 8 characters long.\r\nContains at least one uppercase or lowercase letter.\r\nContains at least one digit.\r\nContains at least one special character from the set @$!%*?&.");

            RuleForEach(x => x.FavouriteGenreIds).GreaterThan(0).WithMessage("Favori Tür ID , sıfırdan büyük olmalıdır");
        }
    }
}
