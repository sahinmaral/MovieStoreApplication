using FluentValidation;

using MovieStoreAppWebAPI.Operations.FilmOperation.Delete;

namespace MovieStoreAppWebAPI.Operations.FilmOperation.Create
{
    public class DeleteFilmViewModelValidator : AbstractValidator<DeleteFilmViewModel>
    {
        public DeleteFilmViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("ID boş bırakılamaz");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID , sıfırdan büyük olmalıdır");
        }
    }
}
