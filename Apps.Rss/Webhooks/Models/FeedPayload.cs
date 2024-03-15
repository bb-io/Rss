using Apps.Rss.Model.Response;

namespace Apps.Rss.Webhooks.Models;

public class FeedPayload
{
    public FeedInfoResponse Feed { get; set; }
    
    public IEnumerable<FeedEntryResponse> NewEntries { get; set; }
}