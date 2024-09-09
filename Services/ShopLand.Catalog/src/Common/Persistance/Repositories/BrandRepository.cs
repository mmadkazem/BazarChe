namespace src.Common.Persistance.Repositories;


public sealed class BrandRepository(CatalogDbContext context) : IBrandRepository
{
    private readonly CatalogDbContext _context = context;
}