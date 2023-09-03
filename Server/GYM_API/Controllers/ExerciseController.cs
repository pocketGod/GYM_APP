
using GYM_LOGICS.Managers;
using GYM_MODELS.Client;
using GYM_MODELS.DB;
using GYM_MODELS.Enums.Anatomy;
using Microsoft.AspNetCore.Mvc;

namespace GYM_LOGICS.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseController : ControllerBase
    {
        private readonly WorkoutManager _workoutManager;

        public ExerciseController(WorkoutManager workoutManager)
        {
            _workoutManager = workoutManager;
        }

        [HttpGet]
        [Route("GetAllExercises")]
        public ActionResult<List<ExerciseDBRecord>> GetAllExercises()
        {
            return Ok(_workoutManager.GetAllExercises());
        }


        [HttpGet]
        [Route("GetByTargetMuscle/{targetMuscle}")]
        public ActionResult<ExerciseByMuscleResponse> GetByTargetMuscle(Muscles targetMuscle)
        {
            return Ok(_workoutManager.GetExercisesByTargetMuscle(targetMuscle));
        }


    }

}
