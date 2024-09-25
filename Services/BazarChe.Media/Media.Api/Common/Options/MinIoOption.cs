namespace Media.Api.Common.Options;


public sealed class MinIoOption
{
    public const string SectionName = "MinIoOption";

    public string MinioEndpoint { get; set; } = null!;
    public string AccessKey { get; set; } = null!;
    public string SecretKey { get; set; } = null!;
}
