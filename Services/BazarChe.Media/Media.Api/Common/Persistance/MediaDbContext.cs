namespace Media.Api.Common.Persistance;

public class MediaDbContext(DbContextOptions<MediaDbContext> options) : DbContext(options)
{
    public DbSet<UrlToken> Tokens { get; set; }
}



public class UrlToken
{
    public Guid Id { get; set; }

    public required string BucketName { get; set; }

    public required string ObjectName { get; set; }

    public required string ContentType { get; set; }

    public DateTime ExpireOn { get; set; }

    public int CountAccess { get; set; }
    public int LimitationAccess { get; set; }
}