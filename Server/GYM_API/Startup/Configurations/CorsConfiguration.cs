namespace GYM_API.Startup.Configurations
{
    public static class CorsConfiguration
    {
        public static void UseCorsConfiguration(WebApplication app)
        {
            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .WithMethods("GET", "POST", "PUT")
                .AllowAnyHeader()
            );
        }
    }

}
