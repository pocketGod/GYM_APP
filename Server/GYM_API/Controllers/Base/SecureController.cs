using GYM_MODELS.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace GYM_API.Controllers.Base
{
    [Authorize]
    public class SecureController : ControllerBase
    {

    }

    public class ReorderTagsDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var tagOrder = new[] { "Authentication", "Data Retrieval", "Workout Creation", "Misc" };

            swaggerDoc.Tags = swaggerDoc.Tags
                .OrderBy(tag => Array.IndexOf(tagOrder, tag.Name))
                .ToList();
        }
    }
}
