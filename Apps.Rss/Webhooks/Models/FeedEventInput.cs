using Blackbird.Applications.Sdk.Common;

namespace Apps.Rss.Webhooks.Models;

public class FeedEventInput
{
    [Display("RSS feed URL")]
    public string FeedUrl { get; set; }
}