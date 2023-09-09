using GYM_API.Controllers.Base;
using GYM_LOGICS.Managers;
using GYM_MODELS.Client.WorkoutCreator;
using GYM_MODELS.DB;
using GYM_MODELS.Settings.Properties;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static GYM_MODELS.Settings.Swagger;

namespace GYM_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : SecureController
    {
        private readonly PropertiesManager _propertiesManager;
        public PropertiesController(PropertiesManager propertiesManager)
        {
            _propertiesManager = propertiesManager;
        }

        /// <summary>
        /// Retrieves all enums properties.
        /// </summary>
        [HttpGet]
        [Route("Enums")]
        [SwaggerOperation(Tags = new[] { nameof(ApiGroupNames.Misc) })]
        public ActionResult<List<EnumPropertiesGroupModel>> Enums()
        {
            return Ok(_propertiesManager.GetEnumsProperties());
        }



        /// <summary>
        /// Retrieves all properties necessary for creating a new workout.
        /// </summary>
        [HttpGet("GetWorkoutCreatorProperties")]
        [SwaggerOperation(Tags = new[] { nameof(ApiGroupNames.WorkoutCreation) })]
        public ActionResult<WorkoutCreatorPropertiesResponse> GetWorkoutCreatorProperties()
        {
            return Ok(_propertiesManager.GetWorkoutCreatorProperties());
        }
    }
}
