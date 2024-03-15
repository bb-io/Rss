namespace Apps.Rss.Model.Response;

public class FeedResponse
{
    public FeedInfoResponse Info { get; set; }
    public IEnumerable<FeedEntryResponse> Entries { get; set; }
}