using FluentValidation;

namespace MovieStoreAppWebAPI.Operations.UserOperation.Read
{
    public class ReadUserViewModelValidator : AbstractValidator<ReadUserViewModel>
    {
        public ReadUserViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("ID boş bırakılamaz");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID , sıfırdan büyük olmalıdır");
        }
    }
}
