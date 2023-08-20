using GYM_LOGICS.Managers;
using GYM_LOGICS.Services;
using GYM_MODELS.DB;
using Microsoft.AspNetCore.Mvc;

namespace GYM_LOGICS.Controllers
{
    [ApiController]
    [Route("api/excercises")]
    public class ExcerciseController : ControllerBase
    {
        private readonly WorkoutManager _workoutManager;

        public ExcerciseController(WorkoutManager workoutManager)
        {
            _workoutManager = workoutManager;
        }

        [HttpGet]
        [Route("GetAllExcercises")]
        public ActionResult<List<ExcerciseDBRecord>> GetAllExcercises()
        {
            return Ok(_workoutManager.GetAllExcercises());
        }

        // Other endpoints...
    }

}
