global using System;
global using BuildingBlocks.CQRS;
global using BuildingBlocks.Behaviours;
global using BuildingBlocks.Exceptions.Handler;
global using Catalog.Api.Models;
global using Mapster;
global using MediatR;
global using Marten;
global using Microsoft.AspNetCore.Mvc;
global using Catalog.Api.Exceptions;
global using FluentValidation;
global using FluentValidation.Results;
global using Microsoft.AspNetCore.Diagnostics;
global using Catalog.Api.UseCases.Products.CreateProduct;
global using Catalog.Api.UseCases.Products.GetProductById;
global using Catalog.Api.UseCases.Products.GetProducts;
global using Catalog.Api.UseCases.Products.GetProductsByCategory;
global using Catalog.Api.UseCases.Products.DeleteProduct;
global using Catalog.Api.UseCases.Products.UpdateProduct;


