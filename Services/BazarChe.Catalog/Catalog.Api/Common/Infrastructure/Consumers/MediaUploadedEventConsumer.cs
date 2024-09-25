namespace Catalog.Api.Common.Infrastructure.Consumers;

public class MediaUploadedEventConsumer(CatalogDbContext catalogDbContext,
                                        ILogger<MediaUploadedEventConsumer> logger)
    : IConsumer<MediaUploadedEvent>
{
    private readonly CatalogDbContext _catalogDbContext = catalogDbContext;
    private readonly ILogger<MediaUploadedEventConsumer> _logger = logger;
    public async Task Consume(ConsumeContext<MediaUploadedEvent> context)
    {
        Console.WriteLine("Is consumer started");
        var catalogItem = await _catalogDbContext.Items
                            .Include(x => x.Medias)
                            .FirstOrDefaultAsync(x => x.Slug == context.Message.CatalogId);

        // TODO: add Saga pattern for remove picture
        if (catalogItem is null)
        {
            _logger.LogError("This catalog by Id: {catalogId} not exist ", context.Message.CatalogId);
            return;
        }

        catalogItem.AddMedia(context.Message.FileName, context.Message.Url);
        await _catalogDbContext.SaveChangesAsync();
    }
}
