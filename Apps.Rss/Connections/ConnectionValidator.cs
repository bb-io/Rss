﻿using Apps.Rss.Api;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;

namespace Apps.Rss.Connections;

public class ConnectionValidator : IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        CancellationToken cancellationToken)
    {
        var endpoint = "/getsubscriptions";
        await new AppClient(authenticationCredentialsProviders.ToArray()).ExecuteWithErrorHandling(new(endpoint));

        return new()
        {
            IsValid = true
        };
    }
}