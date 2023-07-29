using FluentValidation;

namespace MovieStoreAppWebAPI.Operations.GenreOperation.Update
{
    public class UpdateGenreViewModelValidator : AbstractValidator<UpdateGenreViewModel>
    {
        public UpdateGenreViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("ID boş bırakılamaz");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID , sıfırdan büyük olmalıdır");

            RuleFor(x => x.Name).NotNull().WithMessage("İsim boş bırakılamaz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim , minimum 3 karakter olmalıdır");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim , maksimum 50 karakter olmalıdır");
        }
    }
}
