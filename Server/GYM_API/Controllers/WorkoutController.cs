using GYM_LOGICS.Managers;
using GYM_MODELS.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GYM_API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutController : SecureController
    {
        private readonly WorkoutManager _workoutManager;

        public WorkoutController(WorkoutManager workoutManager)
        {
            _workoutManager = workoutManager;
        }


        [HttpGet]
        [Route("GetAllWorkouts")]
        public ActionResult<List<WorkoutDBRecord>> GetAllWorkouts()
        {
            return Ok(_workoutManager.GetAllWorkouts());
        }
    }



}
