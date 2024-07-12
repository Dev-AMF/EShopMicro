namespace Basket.Api.UseCases.DeleteBasket
{
    public class DeleteBasketValidations : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketValidations()
        {
           RuleFor(x => x.DeleteBasketRequest.UserName).NotEmpty().WithMessage("UserName is required");     
        }
    }
}
