global using System;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;

global using BuildingBlocks.CQRS;
global using BuildingBlocks.Behaviours;
global using BuildingBlocks.Exceptions.Handler;

global using Mapster;
global using MediatR;

global using Marten;
global using Marten.Pagination;

global using FluentValidation;
global using FluentValidation.Results;

global using HealthChecks.UI.Client;

global using Catalog.Api.Models;
global using Catalog.Api.DataSeed;
global using Catalog.Api.Exceptions;
global using Catalog.Api.UseCases.Products.GetProducts;
global using Catalog.Api.UseCases.Products.DeleteProduct;
global using Catalog.Api.UseCases.Products.CreateProduct;
global using Catalog.Api.UseCases.Products.UpdateProduct;
global using Catalog.Api.UseCases.Products.GetProductById;
global using Catalog.Api.UseCases.Products.GetProductsByCategory;




