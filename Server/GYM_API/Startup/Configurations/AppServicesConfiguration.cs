using GYM_LOGICS.Builders;
using GYM_LOGICS.Managers;
using GYM_LOGICS.Services;
using GYM_MODELS.Settings;

namespace GYM_API.Startup.Configurations
{
    public static class AppServicesConfiguration
    {
        public static void ConfigureAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            ConfigureApplicationServices(services);
            ConfigureManagers(services);
            ConfigureBuilders(services);
            ConfigureJwtSettings(services, configuration);
        }

        private static void ConfigureApplicationServices(IServiceCollection services)
        {
            services.AddScoped<JWTService>();
            services.AddScoped<AuthService>();
            services.AddScoped<PropertiesService>();
            services.AddScoped<ExerciseService>();
            services.AddScoped<WorkoutService>();
            services.AddScoped<WorkoutPlanService>();
        }

        private static void ConfigureManagers(IServiceCollection services)
        {
            services.AddScoped<WorkoutManager>();
            services.AddScoped<PropertiesManager>();
        }

        private static void ConfigureBuilders(IServiceCollection services)
        {
            services.AddScoped<ExerciseBuilder>();
            services.AddScoped<WorkoutBuilder>();
            services.AddScoped<WorkoutPlanBuilder>();
        }

        private static void ConfigureJwtSettings(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration.GetSection("JwtSettings").Get<JwtSettings>());
        }
    }

}
