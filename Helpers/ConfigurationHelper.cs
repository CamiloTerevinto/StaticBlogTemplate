namespace StaticBlogTemplate.Helpers
{
    public class ConfigurationHelper
    {
        public static void Initialize(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static IConfiguration? Configuration { get; private set; }

        public static string BaseUrl
        {
            get
            {
                return Configuration?["Settings:BaseUrl"] ?? string.Empty;
            }
        }
    }
}
