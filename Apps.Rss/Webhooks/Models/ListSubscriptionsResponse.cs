namespace Apps.Rss.Webhooks.Models;

public class ListSubscriptionsResponse
{
    public IEnumerable<RssEventSubscription> Subscriptions { get; set; }
}