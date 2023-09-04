using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace GYM_MODELS.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class Authorize : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAuthenticated = context.HttpContext.Items["IsAuthenticated"] as bool?;
            if (!isAuthenticated.HasValue || !isAuthenticated.Value)
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
