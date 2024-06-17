namespace Catalog.Api.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        public ProductNotFoundException(string messageParam):base($"No products found with the given {messageParam}!")
        {
                
        }
    }
}
