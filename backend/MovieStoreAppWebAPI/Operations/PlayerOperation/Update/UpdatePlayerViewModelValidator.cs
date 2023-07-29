using FluentValidation;

using MovieStoreAppWebAPI.Operations.PlayerOperation.Update;

namespace MovieStoreAppWebAPI.Operations.PlayerOperation.Create
{
    public class UpdatePlayerViewModelValidator : AbstractValidator<UpdatePlayerViewModel>
    {
        public UpdatePlayerViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("ID boş bırakılamaz");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID , sıfırdan büyük olmalıdır");

            RuleFor(x => x.Name).NotNull().WithMessage("İsim boş bırakılamaz");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("İsim , minimum 3 karakter olmalıdır");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("İsim , maksimum 30 karakter olmalıdır");

            RuleFor(x => x.Surname).NotNull().WithMessage("Soyad boş bırakılamaz");
            RuleFor(x => x.Surname).MinimumLength(3).WithMessage("Soyad , minimum 3 karakter olmalıdır");
            RuleFor(x => x.Surname).MaximumLength(30).WithMessage("Soyad , maksimum 30 karakter olmalıdır");
        }
    }
}
