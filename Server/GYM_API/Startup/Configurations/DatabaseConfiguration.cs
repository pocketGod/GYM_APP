using DatabaseBootstrapLibrary;

namespace GYM_API.Startup.Configurations
{
    public static class DatabaseConfiguration
    {
        public static void ConfigureDatabase(IServiceCollection services, IConfiguration configuration)
        {
            DatabaseBootstrap.Initialize(services, configuration);
        }
    }

}
