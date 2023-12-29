using PortfolioServer.Utility.Exceptions;

namespace PortfolioServer.Utility.Configurations
{
    public class AppSettings
    {
        private static IConfiguration Configuration;
        public static void IntializeConfiguration(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public static string MongoDBConnectionString
        {
            get
            {
                if (Configuration["ConnectionStrings:MongoDBConnection"] == null || string.IsNullOrWhiteSpace(Configuration["ConnectionStrings:MongoDBConnection"]))
                    throw new AppException("MongoDB Connectionstring is not valid in AppSettings file");

                return Configuration["ConnectionStrings:MongoDBConnection"];
            }
        }

        public static string SentryKey
        {
            get
            {

                if (Configuration["ApplicationSettings:SentryKey"] == null || string.IsNullOrWhiteSpace(Configuration["ApplicationSettings:SentryKey"]))
                    throw new AppException("Sentry Config Key is not valid in AppSettings file");

                return Configuration["ApplicationSettings:SentryKey"];
            }
        }

        public static string Environment
        {
            get
            {
                if (Configuration["ApplicationSettings:Environment"] == null || string.IsNullOrWhiteSpace(Configuration["ApplicationSettings:Environment"]))
                    throw new AppException("Environment Key is not valid in AppSettings file");

                return Configuration["ApplicationSettings:Environment"];
            }
        }
    }
}
