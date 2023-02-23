#nullable disable

using Markdig;

namespace StaticBlogTemplate.Utilities;

public class Post
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string RelativeUrl { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastModificationDate { get; set; }
}

public static class PostManager
{
    public static Dictionary<string, Post> Posts { get; } = new Dictionary<string, Post>
    {
        {
            "WelcomeToMyBlog", new Post 
            {
                Title = "Welcome to my new blog!",
                Description = "This is my new blog, hosted statically using the .NET Static Site Generator tool!",
                RelativeUrl = "posts/welcome-to-my-blog",
                CreationDate = new DateTime(2023, 02, 01),
                LastModificationDate = new DateTime(2023, 02, 10),
            }
        }
    };

    public static string GetRenderedMarkdown(IWebHostEnvironment environment, string markdownFilename) 
    {
        var file = File.ReadAllText(Path.Combine(environment.ContentRootPath, "Posts", markdownFilename));
        var pipeline = new MarkdownPipelineBuilder()
            .UseAdvancedExtensions()
            .UseBootstrap()
            .Build();

        return Markdig.Markdown.ToHtml(file, pipeline);
    }
}