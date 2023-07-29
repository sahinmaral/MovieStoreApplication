using FluentValidation;

namespace MovieStoreAppWebAPI.Operations.OrderOperation.Read
{
    public class ReadOrderViewModelValidator : AbstractValidator<ReadOrderViewModel>
    {
        public ReadOrderViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("ID boş bırakılamaz");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID , sıfırdan büyük olmalıdır");
        }
    }
}
