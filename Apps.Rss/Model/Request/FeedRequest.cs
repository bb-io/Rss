using Blackbird.Applications.Sdk.Common;

namespace Apps.Rss.Model.Request;

public class FeedRequest
{
    [Display("RSS feed URL")]
    public string FeedUrl { get; set; }
}