global using Basket.Api.Models;
global using Basket.Api.Repository;
global using Basket.Api.Exceptions;
global using Basket.Api.UseCases.GetBasket;
global using Basket.Api.UseCases.SaharedModels;
global using Basket.Api.UseCases.DeleteBasket;
global using Basket.Api.UseCases.StoreBasket;
global using Basket.Api.UseCases._BasktRepository;
global using Basket.Api.UseCases._BasketEndpoints;



global using System;
global using System.Text.Json;
global using System.Text.Json.Serialization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Http;
global using Microsoft.AspNetCore.Diagnostics;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Caching.Distributed;
global using Microsoft.AspNetCore.Diagnostics.HealthChecks;


global using BuildingBlocks.CQRS;
global using BuildingBlocks.Behaviours;
global using BuildingBlocks.Exceptions;
global using BuildingBlocks.Exceptions.Handler;

global using Marten;
global using Mapster;
global using MediatR;


//global using Marten;
//global using Marten.Pagination;
//global using Marten.Schema;

global using FluentValidation;
global using FluentValidation.Results;

//global using HealthChecks.UI.Client;