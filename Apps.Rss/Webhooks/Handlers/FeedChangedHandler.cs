using Apps.Rss.Webhooks.Handlers.Base;
using Apps.Rss.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Rss.Webhooks.Handlers;

public class FeedChangedHandler : RssEventHandler
{
    public FeedChangedHandler([WebhookParameter] FeedEventInput input) : base(input.FeedUrl)
    {
    }
}