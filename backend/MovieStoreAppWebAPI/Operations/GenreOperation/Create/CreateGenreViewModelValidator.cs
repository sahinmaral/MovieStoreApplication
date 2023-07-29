using FluentValidation;

namespace MovieStoreAppWebAPI.Operations.GenreOperation.Create
{
    public class CreateGenreViewModelValidator : AbstractValidator<CreateGenreViewModel>
    {
        public CreateGenreViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("İsim boş bırakılamaz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim , minimum 3 karakter olmalıdır");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim , maksimum 50 karakter olmalıdır");
        }
    }
}
