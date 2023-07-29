using FluentValidation;

using MovieStoreAppWebAPI.Operations.OrderOperation.Delete;

namespace MovieStoreAppWebAPI.Operations.OrderOperation.Create
{
    public class DeleteOrderViewModelValidator : AbstractValidator<DeleteOrderViewModel>
    {
        public DeleteOrderViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("ID boş bırakılamaz");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID , sıfırdan büyük olmalıdır");
        }
    }
}
