using GYM_LOGICS.Managers;
using GYM_MODELS.Client.WorkoutCreator;
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
            return Ok(_workoutManager.GetAllMyWorkouts());
        }

        [HttpGet]
        [Route("GetWorkoutCreatorProperties")]
        public ActionResult<WorkoutCreatorPropertiesResponse> GetWorkoutCreatorProperties()
        {
            return Ok(_workoutManager.GetWorkoutCreatorProperties());
        }

        [HttpPost]
        [Route("AddNewWorkoutToCollection")]
        public ActionResult<bool> AddNewWorkoutToCollection([FromBody] NewWorkoutSchema newWorkout)
        {
            return Ok(_workoutManager.AddNewWorkoutToCollection(newWorkout));
        }

        [HttpPost]
        [Route("EditWorkoutInCollection")]
        public ActionResult<bool> EditWorkoutInCollection([FromBody] NewWorkoutSchema newWorkout)
        {
            return Ok(_workoutManager.EditWorkoutInCollection(newWorkout));
        }
    }



}
