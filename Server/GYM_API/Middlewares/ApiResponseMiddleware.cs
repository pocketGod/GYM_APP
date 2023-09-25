using GYM_MODELS.Common;
using Newtonsoft.Json;

namespace GYM_API.Middlewares
{
    public class ApiResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public ApiResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Skip middleware for the swagger initialization routes
            if (context.Request.Path.StartsWithSegments("/swagger") ||
                context.Request.Path.StartsWithSegments("/favicon.ico"))
            {
                await _next(context);
                return;
            }

            var originalBody = context.Response.Body;
            using var newBody = new MemoryStream();
            context.Response.Body = newBody;

            await _next(context);

            newBody.Seek(0, SeekOrigin.Begin);

            var responseBody = await new StreamReader(newBody).ReadToEndAsync();

            newBody.Seek(0, SeekOrigin.Begin);

            // Check if the response is already an ApiResponse
            if (!context.Response.Headers.ContainsKey("X-Is-Not-ApiResponse"))
            {
                context.Response.Body = originalBody;
                await context.Response.WriteAsync(responseBody);
                return;
            }

            // Wrap the response in an ApiResponse object
            var apiResponse = new ApiResponse<object>
            {
                result = JsonConvert.DeserializeObject(responseBody),
                status = context.Response.StatusCode,
                isCompleted = true,
                isCompletedSuccessfully = context.Response.StatusCode >= 200 && context.Response.StatusCode < 300
            };

            var apiResponseJson = JsonConvert.SerializeObject(apiResponse);

            context.Response.Body = originalBody;
            await context.Response.WriteAsync(apiResponseJson);
        }


    }

}
