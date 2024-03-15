using Apps.Rss.Api;
using Apps.Rss.Model.Response;
using Apps.Rss.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;

namespace Apps.Rss.Webhooks.Handlers.Base;

public abstract class RssEventHandler : IWebhookEventHandler
{
    private string Url { get; }

    protected RssEventHandler(string url)
    {
        Url = url;
    }

    public Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
        Dictionary<string, string> values)
    {
        var endpoint = $"/subscribe?url={Url}";
        return new AppClient(authenticationCredentialsProvider.ToArray()).ExecuteWithErrorHandling(new(endpoint));
    }

    public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
        Dictionary<string, string> values)
    {
        var client = new AppClient(authenticationCredentialsProvider.ToArray());
        var subscriptions = await ListSubscriptions(client);
        var subscriptionToDelete = subscriptions.Result.Subscriptions.FirstOrDefault(x => x.FeedUrl == Url);

        if (subscriptionToDelete is null)
            return;

        var endpoint = $"removesubscription?id={subscriptionToDelete.SubscriptionId}";
        await client.ExecuteWithErrorHandling(new(endpoint));
    }

    private Task<RssResponse<ListSubscriptionsResponse>> ListSubscriptions(AppClient client)
    {
        var endpoint = "/getsubscriptions";
        return client.ExecuteWithErrorHandling<RssResponse<ListSubscriptionsResponse>>(new(endpoint));
    }
}