using System.Text;

namespace StaticBlogTemplate.Utilities;

public static class RssCreator
{
    public static void Generate()
    {
        var today = DateTime.Today;
        var wrapper = $@"<?xml version=""1.0"" encoding=""utf-8""?>
<rss version=""2.0"" xmlns:atom=""http://www.w3.org/2005/Atom"">
    <channel>
        <title>My Super Blog</title>
        <link>https://www.YOUR_BASE_URL.com/</link>
        <description>The description for the blog content of my site</description>
        <lastBuildDate>{today.ToString("r")}</lastBuildDate>
        <atom:link href=""https://www.YOUR_BASE_URL.com/rss.xml"" rel=""self"" type=""application/rss+xml"" />
        {{0}}
    </channel>
</rss>";

        var stringBuilder = new StringBuilder();

        foreach (var post in PostManager.Posts)
        {
            var fullUrl = $"https://www.YOUR_BASE_URL.com/{post.Value.RelativeUrl}";

            stringBuilder.Append($@"
        <item>
            <title>{post.Value.Title}</title>
            <link>{fullUrl}</link>
            <guid>{fullUrl}</guid>
            <pubDate>{post.Value.CreationDate.ToString("r")}</pubDate>
            <description>{post.Value.Description}</description>
        </item>");
        }

        var final = string.Format(wrapper, stringBuilder);

        File.WriteAllText("wwwroot/rss.xml", final);
    }
}