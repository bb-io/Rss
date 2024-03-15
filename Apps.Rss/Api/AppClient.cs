using Apps.Rss.Constants;
using Apps.Rss.Model.Response;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.Extensions.String;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Newtonsoft.Json;
using RestSharp;

namespace Apps.Rss.Api;

public class AppClient : BlackBirdRestClient
{
    protected override JsonSerializerSettings? JsonSettings => JsonConfig.JsonSettings;

    public AppClient(AuthenticationCredentialsProvider[] creds) : base(new()
    {
        BaseUrl = GetRssApiUrl(creds)
    })
    {
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        var error = JsonConvert.DeserializeObject<ErrorResponse>(response.Content);
        return new(error.Error);
    }

    private static Uri GetRssApiUrl(AuthenticationCredentialsProvider[] creds)
    {
        return $"{Urls.ApiUrl}{creds.Get(CredsNames.ApiKey).Value}".ToUri();
    }
}