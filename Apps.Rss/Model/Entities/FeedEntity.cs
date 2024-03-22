using Apps.Rss.Model.Response;
using Blackbird.Applications.Sdk.Common.Files;

namespace Apps.Rss.Model.Entities;

public class FeedEntity
{
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string Homepage { get; set; }
    
    //public FileReference Content { get; set; }
    
    public IEnumerable<FeedEntryResponse> Entries { get; set; }

    public FeedEntity()
    {
        
    }

    public FeedEntity(FeedInfoResponse info)
    {
        Title = info.Title;
        Description = info.Description;
        Homepage = info.Homepage;
    }
}