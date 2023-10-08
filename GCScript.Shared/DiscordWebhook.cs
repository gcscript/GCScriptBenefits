using GCScript.Shared.Models;
using RestSharp;

namespace GCScript.Shared;

public static class DiscordWebhook
{
    public static async Task<bool> SendMessage(string url, MDiscordWebhook webhook)
    {
        try
        {
            var client = new RestClient(new RestClientOptions() { MaxTimeout = 60000 });
            var request = new RestRequest(url, Method.Post);
            request.AddJsonBody(webhook);
            RestResponse response = await client.ExecuteAsync(request);
            return true;
        }
        catch { return false; }
    }
}
