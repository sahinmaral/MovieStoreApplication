using FluentValidation;

namespace MovieStoreAppWebAPI.Operations.PlayerOperation.Read
{
    public class ReadPlayerViewModelValidator : AbstractValidator<ReadPlayerViewModel>
    {
        public ReadPlayerViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("ID boş bırakılamaz");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID , sıfırdan büyük olmalıdır");
        }
    }
}
