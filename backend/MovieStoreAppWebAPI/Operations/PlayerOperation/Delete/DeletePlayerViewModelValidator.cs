using FluentValidation;

using MovieStoreAppWebAPI.Operations.PlayerOperation.Delete;

namespace MovieStoreAppWebAPI.Operations.PlayerOperation.Create
{
    public class DeletePlayerViewModelValidator : AbstractValidator<DeletePlayerViewModel>
    {
        public DeletePlayerViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("ID boş bırakılamaz");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID , sıfırdan büyük olmalıdır");
        }
    }
}
