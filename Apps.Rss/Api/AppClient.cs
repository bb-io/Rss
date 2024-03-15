using Apps.Rss.Constants;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using RestSharp;

namespace Apps.Rss.Api;

public class AppClient : BlackBirdRestClient
{
    public AppClient(AuthenticationCredentialsProvider[] creds) : base(new()
    {
        BaseUrl = GetRssApiUrl(creds)
    })
    {
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        throw new NotImplementedException();
    }
    
    private static Uri GetRssApiUrl(AuthenticationCredentialsProvider[] creds)
    {
        return $"{Urls.ApiUrl}{creds.Get(CredsNames.ApiKey).Value}".ToUri();
    }
}