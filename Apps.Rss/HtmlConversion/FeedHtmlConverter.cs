using System.Text;
using Apps.Rss.HtmlConversion.Constants;
using Apps.Rss.Model.Response;
using HtmlAgilityPack;

namespace Apps.Rss.HtmlConversion;

public static class FeedHtmlConverter
{
    public static byte[] ToHtml(IEnumerable<FeedEntryResponse> resultEntries)
    {
        var (doc, body) = PrepareEmptyHtmlDocument();

        resultEntries.ToList().ForEach(x => ParseFeedEntry(x, doc, body));

        return Encoding.UTF8.GetBytes(doc.DocumentNode.OuterHtml);
    }

    private static void ParseFeedEntry(FeedEntryResponse feedEntry, HtmlDocument doc, HtmlNode body)
    {
        var entryNode = doc.CreateElement(HtmlConstants.Div);

        var titleNode = doc.CreateElement(HtmlConstants.H1);
        titleNode.InnerHtml = feedEntry.Title;

        var descriptionNode = doc.CreateElement(HtmlConstants.Paragraph);
        descriptionNode.InnerHtml = feedEntry.Description;

        var linkNode = doc.CreateElement(HtmlConstants.A);
        linkNode.SetAttributeValue("href", feedEntry.Link);
        linkNode.InnerHtml = feedEntry.Link;

        var contentNode = doc.CreateElement(HtmlConstants.Div);
        
        if(feedEntry.Content?.Html is not null)
            contentNode.InnerHtml = feedEntry.Content.Html;

        entryNode.AppendChild(titleNode);
        entryNode.AppendChild(descriptionNode);
        entryNode.AppendChild(linkNode);
        entryNode.AppendChild(contentNode);

        body.AppendChild(entryNode);
    }

    private static (HtmlDocument document, HtmlNode bodyNode) PrepareEmptyHtmlDocument()
    {
        var htmlDoc = new HtmlDocument();
        var htmlNode = htmlDoc.CreateElement(HtmlConstants.Html);
        htmlDoc.DocumentNode.AppendChild(htmlNode);
        htmlNode.AppendChild(htmlDoc.CreateElement(HtmlConstants.Head));

        var bodyNode = htmlDoc.CreateElement(HtmlConstants.Body);
        htmlNode.AppendChild(bodyNode);

        return (htmlDoc, bodyNode);
    }
}