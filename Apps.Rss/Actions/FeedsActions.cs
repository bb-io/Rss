using System.Net.Mime;
using Apps.Rss.HtmlConversion;
using Apps.Rss.Invocables;
using Apps.Rss.Model.Entities;
using Apps.Rss.Model.Request;
using Apps.Rss.Model.Response;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;

namespace Apps.Rss.Actions;

[ActionList]
public class FeedsActions : AppInvocable
{
    private readonly IFileManagementClient _fileManagementClient;

    public FeedsActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : base(
        invocationContext)
    {
        _fileManagementClient = fileManagementClient;
    }

    [Action("Get feed", Description = "Get content of a specific feed")]
    public async Task<FeedEntity> GetFeed([ActionParameter] FeedRequest input)
    {
        var endpoint = $"/get?url={input.FeedUrl}";
        var response = await Client.ExecuteWithErrorHandling<RssResponse<FeedResponse>>(new(endpoint));

        var html = FeedHtmlConverter.ToHtml(response.Result.Entries);

        return new(response.Result.Info)
        {
            Content = await _fileManagementClient.UploadAsync(new MemoryStream(html), MediaTypeNames.Text.Html,
                $"{response.Result.Info.Title}.html")
        };
    }
}