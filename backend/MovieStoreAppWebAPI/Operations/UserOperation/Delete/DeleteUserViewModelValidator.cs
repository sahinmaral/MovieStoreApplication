using FluentValidation;

namespace MovieStoreAppWebAPI.Operations.UserOperation.Delete
{
    public class DeleteUserViewModelValidator : AbstractValidator<DeleteUserViewModel>
    {
        public DeleteUserViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("ID boş bırakılamaz");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID , sıfırdan büyük olmalıdır");
        }
    }
}
