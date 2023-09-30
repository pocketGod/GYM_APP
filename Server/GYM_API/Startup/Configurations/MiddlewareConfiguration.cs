using GYM_API.Middlewares;

namespace GYM_API.Startup.Configurations
{
    public static class MiddlewareConfiguration
    {
        public static void UseMiddlewareConfiguration(WebApplication app)
        {
            app.UseMiddleware<TokenMiddleware>();
            app.UseMiddleware<ApiResponseMiddleware>();
        }
    }

}
