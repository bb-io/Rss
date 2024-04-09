using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Metadata;

namespace Apps.Rss;

public class Application : IApplication, ICategoryProvider
{
    public string Name
    {
        get => "Rss";
        set { }
    }

    public IEnumerable<ApplicationCategory> Categories
    {
        get => [ApplicationCategory.Utilities];
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}