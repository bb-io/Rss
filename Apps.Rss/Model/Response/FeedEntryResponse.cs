namespace Apps.Rss.Model.Response;

public class FeedEntryResponse
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string Link { get; set; }
    
    public FeedContentResponse Content { get; set; }
}