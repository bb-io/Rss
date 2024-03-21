using System.Net;
using Apps.Rss.Constants;
using Apps.Rss.Webhooks.Handlers;
using Apps.Rss.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Newtonsoft.Json;

namespace Apps.Rss.Webhooks;

[WebhookList]
public class WebhookList
{
    [Webhook("On feed changed", typeof(FeedChangedHandler), Description = "On specific feed changed")]
    public Task<WebhookResponse<FeedWebhookResponse>> OnFeedChanged(WebhookRequest request)
    {
        var payload = request.Body.ToString();
        ArgumentException.ThrowIfNullOrEmpty(payload);

        var data = JsonConvert.DeserializeObject<FeedPayload>(payload, JsonConfig.JsonSettings)!;

        return Task.FromResult<WebhookResponse<FeedWebhookResponse>>(new()
        {
            HttpResponseMessage = new() { StatusCode = HttpStatusCode.OK },
            Result = new(data.Feed)
            {
                Entries = data.NewEntries
            }
        });
    }
}