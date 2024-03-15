using Apps.Rss.Invocables;
using Apps.Rss.Model.Request;
using Apps.Rss.Model.Response;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Newtonsoft.Json.Linq;

namespace Apps.Rss.Actions;

[ActionList]
public class FeedsActions : AppInvocable
{
    public FeedsActions(InvocationContext invocationContext) : base(invocationContext)
    {
    }

    [Action("Get feed", Description = "Get content of a specific feed")]
    public async Task<FeedResponse> GetFeed([ActionParameter] FeedRequest input)
    {
        var endpoint = $"/get?url={input.FeedUrl}";
        var response = await Client.ExecuteWithErrorHandling<JObject>(new(endpoint));

        return default;
    }
}