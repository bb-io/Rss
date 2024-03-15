using System.Net;
using System.Net.Mime;
using Apps.Rss.Constants;
using Apps.Rss.HtmlConversion;
using Apps.Rss.Model.Entities;
using Apps.Rss.Webhooks.Handlers;
using Apps.Rss.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Webhooks;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Newtonsoft.Json;

namespace Apps.Rss.Webhooks;

[WebhookList]
public class WebhookList
{
    private readonly IFileManagementClient _fileManagementClient;

    public WebhookList(IFileManagementClient fileManagementClient)
    {
        _fileManagementClient = fileManagementClient;
    }

    [Webhook("On feed changed", typeof(FeedChangedHandler), Description = "On specific feed changed")]
    public async Task<WebhookResponse<FeedEntity>> OnFeedChanged(WebhookRequest request)
    {
        var payload = request.Body.ToString();
        ArgumentException.ThrowIfNullOrEmpty(payload);

        var data = JsonConvert.DeserializeObject<FeedPayload>(payload, JsonConfig.JsonSettings)!;
        var html = FeedHtmlConverter.ToHtml(data.NewEntries);

        return new()
        {
            HttpResponseMessage = new() { StatusCode = HttpStatusCode.OK },
            Result = new(data.Feed)
            {
                Content = await _fileManagementClient.UploadAsync(new MemoryStream(html), MediaTypeNames.Text.Html,
                    $"{data.Feed.Title}.html")
            }
        };
    }
}