using FluentValidation;

namespace MovieStoreAppWebAPI.Operations.FilmOperation.Update
{
    public class UpdateFilmViewModelValidator : AbstractValidator<UpdateFilmViewModel>
    {
        public UpdateFilmViewModelValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("ID boş bırakılamaz");
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("ID , sıfırdan büyük olmalıdır");

            RuleFor(x => x.Name).NotNull().WithMessage("İsim , boş bırakılamaz");
            RuleFor(x => x.Name).MinimumLength(2).WithMessage("İsim , minimum 2 karakter olmalıdır");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("İsim , maksimum 100 karakter olmalıdır");

            RuleFor(x => x.About).NotNull().WithMessage("Hakkında , boş bırakılamaz");
            RuleFor(x => x.About).MinimumLength(10).WithMessage("Hakkında , minimum 10 karakter olmalıdır");
            RuleFor(x => x.About).MaximumLength(1000).WithMessage("Hakkında , maksimum 1000 karakter olmalıdır");

            RuleFor(x => x.Price).NotNull().WithMessage("Fiyat , boş bırakılamaz");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Fiyat , sıfırdan büyük olmalıdır");

            RuleFor(x => x.DirectorId).NotNull().WithMessage("Yönetmen ID , boş bırakılamaz");
            RuleFor(x => x.DirectorId).GreaterThan(0).WithMessage("Yönetmen ID , sıfırdan büyük olmalıdır");

            RuleFor(x => x.GenreId).NotNull().WithMessage("Tür ID , boş bırakılamaz");
            RuleFor(x => x.GenreId).GreaterThan(0).WithMessage("Tür ID , sıfırdan büyük olmalıdır");

            RuleForEach(x => x.PlayerIds).NotNull().WithMessage("Oyuncu ID , boş bırakılamaz");
            RuleForEach(x => x.PlayerIds).GreaterThan(0).WithMessage("Oyuncu ID , sıfırdan büyük olmalıdır");

            RuleFor(x => x.PublishedDate).NotNull().WithMessage("Yayınlandığı tarih , boş bırakılamaz");
            RuleFor(x => x.PublishedDate).LessThan(DateTime.Now).WithMessage("Yayınlandığı tarih , geçerli olmalıdır");
        }
    }
}
