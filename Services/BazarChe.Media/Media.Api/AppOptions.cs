namespace Media.Api;


public sealed class MinIoOption
{
    public const string SectionName = "MinIoOption";

    public required string MinioEndpoint { get; set; }
    public required string AccessKey { get; set; }
    public required string SecretKey { get; set; }
}


public sealed class BrokerOption
{
    public const string SectionName = "BrokerOption";

    public required string Host { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
}