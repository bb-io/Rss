using Blackbird.Applications.Sdk.Common;

namespace Apps.Rss.Webhooks.Models;

public class FeedEventInput
{
    [Display("RSS feed URLs")]
    public IEnumerable<string> FeedUrls { get; set; }
}