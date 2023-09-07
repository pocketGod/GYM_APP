
using GYM_API.Controllers.Base;
using GYM_LOGICS.Managers;
using GYM_MODELS.Client;
using GYM_MODELS.DB;
using GYM_MODELS.Enums.Anatomy;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static GYM_MODELS.Settings.Swagger;

namespace GYM_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : SecureController
    {
        private readonly WorkoutManager _workoutManager;

        public ExerciseController(WorkoutManager workoutManager)
        {
            _workoutManager = workoutManager;
        }

        /// <summary>
        /// Retrieves all exercises.
        /// </summary>
        [HttpGet]
        [Route("GetAllExercises")]
        [SwaggerOperation(Tags = new[] { nameof(ApiGroupNames.DataRetrieval) })]
        public ActionResult<List<ExerciseDBRecord>> GetAllExercises()
        {
            return Ok(_workoutManager.GetAllExercises());
        }


        /// <summary>
        /// Retrieves exercises by target muscle.
        /// </summary>
        [HttpGet]
        [Route("GetByTargetMuscle/{targetMuscle}")]
        [SwaggerOperation(Tags = new[] { nameof(ApiGroupNames.DataRetrieval) })]
        public ActionResult<ExerciseByMuscleResponse> GetByTargetMuscle(Muscles targetMuscle)
        {
            return Ok(_workoutManager.GetExercisesByTargetMuscle(targetMuscle));
        }


    }

}
