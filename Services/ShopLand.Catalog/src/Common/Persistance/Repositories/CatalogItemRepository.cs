namespace src.Common.Persistance.Repositories;



public sealed class CatalogItemRepository(CatalogDbContext context) : ICatalogItemRepository
{
    private readonly CatalogDbContext _context = context;
}