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
global using Catalog.Api.Features.CatalogCategory.UseCase.Queries.GetCategoryById;
global using Catalog.Api.Features.CatalogCategory.UseCase.Queries.GetCategories;
global using Catalog.Api.Features.CatalogItem.Common.Exceptions;
global using Catalog.Api.Features.CatalogBrand.UseCase.Queries;
global using Catalog.Api.Features.CatalogItem.UseCase.Queries;
global using Catalog.Api.Common.Persistance.Repositories;
global using Catalog.Api.Features.CatalogCategory.Common;
global using Catalog.Api.Common.Persistance.UnitOfWorks;
global using Catalog.Api.Features.CatalogBrand.Common;
global using Catalog.Api.Features.CatalogItem.Common;
global using Catalog.Api.Common.Exceptions.Handlers;
global using Catalog.Api.Common.Persistance.Context;
global using Catalog.Api.Common.Extensions;
global using Catalog.Api.Common.Exceptions;
global using Catalog.Api.Common.Behaviors;


