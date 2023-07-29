using FluentValidation;

using MovieStoreAppWebAPI.Operations.GenreOperation.Delete;

namespace MovieStoreAppWebAPI.Operations.GenreOperation.Create
{
    public class DeleteGenreViewModelValidator : AbstractValidator<DeleteGenreViewModel>
    {
        public DeleteGenreViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("ID boş bırakılamaz");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID , sıfırdan büyük olmalıdır");
        }
    }
}
