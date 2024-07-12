namespace Basket.Api.UseCases.StoreBasket
{
    public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
    {
        public StoreBasketCommandValidator()
        {
            RuleFor(x => x.StoreBasketRequest).NotNull().WithMessage("Cart can not be null.");
            RuleFor(x => x.StoreBasketRequest.UserName).NotEmpty().WithMessage("UserName is required");
        }
    }
}
