using Blackbird.Applications.Sdk.Common;

namespace Apps.Rss;

public class Application : IApplication
{
    public string Name
    {
        get => "Rss";
        set { }
    }

    public T GetInstance<T>()
    {
        throw new NotImplementedException();
    }
}