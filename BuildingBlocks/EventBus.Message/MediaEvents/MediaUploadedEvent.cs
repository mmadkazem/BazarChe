namespace EventBus.Message.MediaEvents;

public record MediaUploadedEvent(string FileName, string Url, string CatalogId, DateTime OccurredOn);
