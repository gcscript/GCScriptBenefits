using System.Text.Json.Serialization;

namespace GCScript.Shared.Models;

public class MDiscordWebhook
{
    [JsonPropertyName("username")]
    public required string Username { get; set; }

    [JsonPropertyName("content")]
    public required string Content { get; set; }
}
