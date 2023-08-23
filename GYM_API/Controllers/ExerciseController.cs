using GYM_LOGICS.Managers;
using GYM_LOGICS.Services;
using GYM_MODELS.DB;
using Microsoft.AspNetCore.Mvc;

namespace GYM_LOGICS.Controllers
{
    [ApiController]
    [Route("api/exercises")]
    public class ExerciseController : ControllerBase
    {
        private readonly WorkoutManager _workoutManager;

        public ExerciseController(WorkoutManager workoutManager)
        {
            _workoutManager = workoutManager;
        }

        [HttpGet]
        [Route("GetAllExercises")]
        public ActionResult<List<ExcerciseDBRecord>> GetAllExcercises()
        {
            return Ok(_workoutManager.GetAllExcercises());
        }

        
    }

}
