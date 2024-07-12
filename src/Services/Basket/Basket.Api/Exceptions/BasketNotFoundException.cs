

namespace Basket.Api.Exceptions
{
    public class BasketNotFoundException : NotFoundException
    {
        public BasketNotFoundException(string username) : base($"No carts were found with the given Username :{username}!")
        {

        }
    }
}
