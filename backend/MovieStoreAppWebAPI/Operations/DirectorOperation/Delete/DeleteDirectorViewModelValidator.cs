using FluentValidation;

using MovieStoreAppWebAPI.Operations.DirectorOperation.Delete;

namespace MovieStoreAppWebAPI.Operations.DirectorOperation.Create
{
    public class DeleteDirectorViewModelValidator : AbstractValidator<DeleteDirectorViewModel>
    {
        public DeleteDirectorViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("ID boş bırakılamaz");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID , sıfırdan büyük olmalıdır");
        }
    }
}
