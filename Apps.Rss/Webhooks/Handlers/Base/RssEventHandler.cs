using Apps.Rss.Api;
using Apps.Rss.Model.Response;
using Apps.Rss.Webhooks.Models;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Webhooks;
using RestSharp;

namespace Apps.Rss.Webhooks.Handlers.Base;

public abstract class RssEventHandler : IWebhookEventHandler
{
    private IEnumerable<string> Urls { get; }

    protected RssEventHandler(IEnumerable<string> urls)
    {
        Urls = urls;
    }

    public async Task SubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
        Dictionary<string, string> values)
    {
        var client = new AppClient(authenticationCredentialsProvider.ToArray());
        
        await client.ExecuteWithErrorHandling(new($"/setwebhook?url={values["payloadUrl"]}", Method.Post));

        var subscriptions = await ListSubscriptions(client);

        foreach (var subscription in subscriptions.Result.Subscriptions)
        {
            var endpoint = $"removesubscription?id={subscription.SubscriptionId}";
            await client.ExecuteWithErrorHandling(new(endpoint));
        }

        foreach (var url in Urls)
        {
            await client.ExecuteWithErrorHandling(new($"/subscribe?url={url}"));
        }        
    }

    public async Task UnsubscribeAsync(IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProvider,
        Dictionary<string, string> values)
    {
        var client = new AppClient(authenticationCredentialsProvider.ToArray());
        var subscriptions = await ListSubscriptions(client);

        foreach (var subscription in subscriptions.Result.Subscriptions)
        {
            var endpoint = $"removesubscription?id={subscription.SubscriptionId}";
            await client.ExecuteWithErrorHandling(new(endpoint));
        }        
    }

    private Task<RssResponse<ListSubscriptionsResponse>> ListSubscriptions(AppClient client)
    {
        var endpoint = "/getsubscriptions";
        return client.ExecuteWithErrorHandling<RssResponse<ListSubscriptionsResponse>>(new(endpoint));
    }
}