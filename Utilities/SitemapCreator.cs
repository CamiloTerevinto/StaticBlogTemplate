using StaticBlogTemplate.Helpers;
using System.Text;

namespace StaticBlogTemplate.Utilities;

public static class SitemapCreator
{
    public static void Generate()
    {
        var today = DateTime.Today;
        var wrapper = @"<?xml version=""1.0"" encoding=""utf-8""?>
<urlset xmlns=""http://www.sitemaps.org/schemas/sitemap/0.9"">
{0}
</urlset>";

        var template = @"
    <url>
        <loc>{0}</loc>
        <lastmod>{1}</lastmod>
    </url>";

        var stringBuilder = new StringBuilder();
        var baseUrl = $"{ConfigurationHelper.BaseUrl}/";

        stringBuilder.AppendFormat(template, baseUrl, "2023-02-10");

        foreach (var post in PostManager.Posts)
        {
            var fullUrl = $"{baseUrl}{post.Value.RelativeUrl}";

            stringBuilder.AppendFormat(template, fullUrl, post.Value.LastModificationDate);
        }

        var final = string.Format(wrapper, stringBuilder);

        File.WriteAllText("wwwroot/sitemap.xml", final);
    }
}