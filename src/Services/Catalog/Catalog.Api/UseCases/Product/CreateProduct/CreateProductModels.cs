﻿namespace Catalog.Api.UseCases.Products.CreateProduct
{
    public record CreateProductRequest(string Name, List<string> Category, string Description,
                                      string ImageFile, decimal Price);

    public record CreateProductResponse(Guid id);

    
}
