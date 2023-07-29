using FluentValidation;

namespace MovieStoreAppWebAPI.Operations.DirectorOperation.Create
{
    public class CreateDirectorViewModelValidator : AbstractValidator<CreateDirectorViewModel>
    {
        public CreateDirectorViewModelValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("İsim boş bırakılamaz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim , minimum 3 karakter olmalıdır");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("İsim , maksimum 50 karakter olmalıdır");

            RuleFor(x => x.Surname).NotNull().WithMessage("Soyad boş bırakılamaz");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Soyad , minimum 3 karakter olmalıdır");
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage("Soyad , maksimum 50 karakter olmalıdır");
        }
    }
}
