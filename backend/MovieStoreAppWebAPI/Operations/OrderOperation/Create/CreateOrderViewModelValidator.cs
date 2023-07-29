using FluentValidation;

namespace MovieStoreAppWebAPI.Operations.OrderOperation.Create
{
    public class CreateOrderViewModelValidator : AbstractValidator<CreateOrderViewModel>
    {
        public CreateOrderViewModelValidator()
        {
            RuleFor(x => x.UserUsername).NotNull().WithMessage("Kullanıcı adı boş bırakılamaz");

            RuleFor(x => x.FilmId).NotNull().WithMessage("Film ID boş bırakılamaz");
            RuleFor(x => x.FilmId).GreaterThan(0).WithMessage("Film ID , sıfırdan büyük olmalıdır");
        }
    }
}
