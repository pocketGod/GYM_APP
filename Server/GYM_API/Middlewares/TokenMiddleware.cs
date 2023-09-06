using GYM_LOGICS.Extensions;
using GYM_MODELS.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
            // If authentication is disabled (for debugging purposes)
            if (!_jwtSettings.IsAuthenticationActive)
            {
                await _next(context);
                return;
            }

            // Skip middleware for the auth and the swagger initialization routes
            if (context.Request.Path.StartsWithSegments("/api/auth") ||
                context.Request.Path.StartsWithSegments("/swagger") ||
                context.Request.Path.StartsWithSegments("/favicon.ico") ||
                context.Request.Path.StartsWithSegments("/api/Resources/swagger-customization.js"))
            {
                await _next(context);
                return;
            }


            string authorizationHeader = context.Request.Headers["Authorization"].FirstOrDefault();
            string token = null;
            if (authorizationHeader != null)
            {
                string[] parts = authorizationHeader.Split(" ");
                token = parts.Last();
            }

            byte[] key = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();

            if (token != null)
            {
                try
                {
                    TokenValidationParameters tokenValidationParameters = new()
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };

                    SecurityToken validatedToken;
                    jwtTokenHandler.ValidateToken(token, tokenValidationParameters, out validatedToken);

                    JwtSecurityToken jwtToken = jwtTokenHandler.ReadToken(token) as JwtSecurityToken;
                    Claim userIdClaim = jwtToken.Claims.First(x => x.Type == JwtRegisteredClaimNames.Sub);
                    string userId = userIdClaim.Value;

                    if (!userId.IsValidMongoDBObjectId())
                    {
                        await SetUnauthorizedResponse(context);
                        return;
                    }

                    context.Items["UserId"] = userId;
                    context.Items["IsAuthenticated"] = true;
                }
                catch
                {
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
            context.Items["IsAuthenticated"] = false;
            context.Items["IsAuthorized"] = false;
            await context.Response.WriteAsync("Unauthorized");
        }

    }
}
