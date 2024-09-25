namespace Media.Api.Common.Options;

public class MongoDbOption
{
    public const string SectionName = "MongoDbOption";

    public string Host { get; set; } = null!;
    public string DatabaseName { get; set; } = null!;
}