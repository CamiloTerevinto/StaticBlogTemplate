using StaticBlogTemplate.Helpers;
using StaticBlogTemplate.Utilities;

var builder = WebApplication.CreateBuilder(args);

ConfigurationHelper.Initialize(builder.Configuration);

// Add services to the container.
var mvcBuilder = builder.Services.AddControllersWithViews();

#if DEBUG
mvcBuilder.AddRazorRuntimeCompilation();

RssCreator.Generate();
SitemapCreator.Generate();
#endif

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
