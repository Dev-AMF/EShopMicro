using BuildingBlocks.Exceptions;

namespace Catalog.Api.Exceptions
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(string messageParam):base($"No products found with the given {messageParam}!")
        {
                
        }
        public ProductNotFoundException(Guid id):base("Product", id)
        {
                
        }
    }
}
