using Apps.Rss.Model.Response;

namespace Apps.Rss.Webhooks.Models;

public class FeedWebhookResponse
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string Homepage { get; set; }
    
    public IEnumerable<FeedEntryResponse> Entries { get; set; }

    public FeedWebhookResponse()
    {
        
    }

    public FeedWebhookResponse(FeedInfoResponse info)
    {
        Title = info.Title;
        Description = info.Description;
        Homepage = info.Homepage;
    }
}