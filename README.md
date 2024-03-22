# Blackbird.io RSS API

Blackbird is the new automation backbone for the language technology industry. Blackbird provides enterprise-scale automation and orchestration with a simple no-code/low-code platform. Blackbird enables ambitious organizations to identify, vet and automate as many processes as possible. Not just localization workflows, but any business and IT process. This repository represents an application that is deployable on Blackbird and usable inside the workflow editor.

## Introduction

<!-- begin docs -->

RSS API is a simply application that subscribes to RSS feeds and turns them into webhook events. Blackbird can listen to these events and trigger workflows for you accordingly.

## Before setting up

Before you can connect you need to make sure that:

- You have an RSS API account.

## Connecting

1. Navigate to apps and search for RSS API. If you cannot find RSS API then click _Add App_ in the top right corner, select RSS API and add the app to your Blackbird environment.
2. Click _Add Connection_.
3. Name your connection for future reference e.g. 'My feed'.
4. In RSS API, create a new application and copy the API Key.
5. Fill in the API Key in your connection.
6. Click _Connect_.

![1711120596050](image/README/1711120596050.png)

### Actions

- **Get feed** returns the current state any RSS feed you point it at: all the items and a description of the feed.

### Events

- **On feed changed** is triggered whenever RSS API detects a change to a feed. It outputs the feed title and description, as well as multiple new items.

## Usage

RSS API works a little different than other Blackbird apps. The main thing to note is that **you need to create a new application in RSS API, connection in Blackbird for every bird**. Once you have set up your first bird, you can specify any number of RSS feed URLs to subscribe to. Blackbird will automatically update your RSS API application with the URLs and connect its own webhook URL to it.

If you were to create a new bird using the same connection, the new bird will overwrite the old bird and the old bird will stop working. Therefore, we recommend you use one connection per bird.

## Example

![1711122025115](image/README/1711122025115.png)

This example shows a bird that is subscribed to different news outlets and will be triggered whenever these outlets publish new articles.

After receiving new articles, we use the _Extract content_ utility action to get the content from the web page. We then use OpenAI to create a summary of the content and we send this summary to ourselves on Slack.

## Feedback

Do you want to use this app or do you have feedback on our implementation? Reach out to us using the [established channels](https://www.blackbird.io/) or create an issue.

<!-- end docs -->
