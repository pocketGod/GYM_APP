using GYM_LOGICS.Managers;
using GYM_MODELS.DB;
using Microsoft.AspNetCore.Mvc;

namespace GYM_LOGICS.Controllers
{
    [ApiController]
    [Route("api/exercise")]
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

        
    }

}
