namespace Catalog.Api.Common.Persistance.UnitOfWorks;


public interface IUnitOfWork
{
    ICategoryRepository Categories { get; }
    IBrandRepository Brands { get; }
    ICatalogItemRepository CatalogItems { get; }

    Task SaveChangesAsync(CancellationToken token);
}