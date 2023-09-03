using GYM_MODELS.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace GYM_API.Middlewares
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JwtSettings _jwtSettings;

        public TokenMiddleware(RequestDelegate next, JwtSettings jwtSettings)
        {
            _next = next;
            _jwtSettings = jwtSettings;
        }

        public async Task Invoke(HttpContext context)
        {
            // Skip middleware for the auth and the swagger initialization routes
            if (context.Request.Path.StartsWithSegments("/api/auth") || context.Request.Path.StartsWithSegments("/swagger") || context.Request.Path.StartsWithSegments("/favicon.ico"))
            {
                await _next(context);
                return;
            }

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            var key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            if (token != null)
            {
                try
                {
                    jwtTokenHandler.ValidateToken(token, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    }, out SecurityToken validatedToken);

                    context.Items["IsAuthenticated"] = true;
                }
                catch
                {
                    context.Items["IsAuthenticated"] = false;
                    await SetUnauthorizedResponse(context);
                    return;
                }
            }
            else
            {
                await SetUnauthorizedResponse(context);
                return;
            }

            context.Items["IsAuthorized"] = true;
            await _next(context);
        }

        private async Task SetUnauthorizedResponse(HttpContext context)
        {
            context.Response.StatusCode = 401;
            context.Items["IsAuthorized"] = false;
            await context.Response.WriteAsync("Unauthorized");
        }

    }
}
