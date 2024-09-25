using System.Text.Json;

namespace EventBus.Message.Options;

public sealed class BrokerOptionFactory
{
    public static BrokerOption Create()
    {
        var baseDirectory = "E:/Project/BazarChe";
        // var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string path = Path.Combine
        (
            baseDirectory,
            "BuildingBlocks",
            "EventBus.Message",
            "Options",
            "BrokerOptionConfiguration.json"
        );
        using var r = new StreamReader(path);
        string json = r.ReadToEnd();
        return JsonSerializer.Deserialize<BrokerOption>(json)!;
    }
}