// built-in
global using Microsoft.EntityFrameworkCore.Metadata.Builders;
global using Microsoft.AspNetCore.Http.HttpResults;
global using System.Text.RegularExpressions;
global using Microsoft.EntityFrameworkCore;
global using System.Collections.Immutable;
global using Microsoft.OpenApi.Models;
global using System.Linq.Expressions;
global using System.Reflection;
global using System.Text.Json;


// third-party
global using FluentValidation.Results;
global using FluentValidation;
global using MediatR;
global using Carter;



// solution
global using src.Features.CatalogCategory.UseCase.Queries.GetCategoryById;
global using src.Features.CatalogCategory.UseCase.Queries.GetCategories;
global using src.Features.CatalogItem.Common.Exceptions;
global using src.Features.CatalogBrand.UseCase.Queries;
global using src.Features.CatalogItem.UseCase.Queries;
global using src.Common.Persistance.Repositories;
global using src.Features.CatalogCategory.Common;
global using src.Common.Persistance.UnitOfWorks;
global using src.Features.CatalogBrand.Common;
global using src.Features.CatalogItem.Common;
global using src.Common.Exceptions.Handlers;
global using src.Common.Persistance.Context;
global using src.Common.Extensions;
global using src.Common.Exceptions;
global using src.Common.Behaviors;


