namespace EventBus.Message.Options;


public sealed class BrokerOption(string host)
{
    public string Host { get; private set; } = host;
}