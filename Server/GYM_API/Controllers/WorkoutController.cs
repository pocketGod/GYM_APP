﻿using GYM_API.Controllers.Base;
using GYM_LOGICS.Managers;
using GYM_MODELS.Client;
using GYM_MODELS.Client.WorkoutCreator;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static GYM_MODELS.Settings.Swagger;

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

        /// <summary>
        /// Retrieves all workouts plans for the current user.
        /// </summary>
        [HttpGet]
        [Route("GetAllPlans")]
        [SwaggerOperation(Tags = new[] { nameof(ApiGroupNames.DataRetrieval) })]
        public ActionResult<List<WorkoutPlan>> GetAllPlans()
        {
            return Ok(_workoutManager.GetAllMyPlans());
        }


        /// <summary>
        /// Retrieves all workouts for the current user.
        /// </summary>
        [HttpGet]
        [Route("GetAllWorkouts")]
        [SwaggerOperation(Tags = new[] { nameof(ApiGroupNames.DataRetrieval) })]
        public ActionResult<List<Workout>> GetAllWorkouts()
        {
            return Ok(_workoutManager.GetAllMyWorkouts());
        }


        /// <summary>
        /// Adds a new workout to the database.
        /// </summary>
        [HttpPost("AddNewWorkoutToCollection")]
        [SwaggerOperation(Tags = new[] { nameof(ApiGroupNames.WorkoutCreation) })]
        public ActionResult<bool> AddNewWorkoutToCollection([FromBody] NewWorkoutSchema newWorkout)
        {
            return Ok(_workoutManager.AddNewWorkoutToCollection(newWorkout));
        }


        /// <summary>
        /// Edits an existing workout in the database.
        /// </summary>
        [HttpPost("EditWorkoutInCollection")]
        [SwaggerOperation(Tags = new[] { nameof(ApiGroupNames.WorkoutCreation) })]
        public ActionResult<bool> EditWorkoutInCollection([FromBody] NewWorkoutSchema newWorkout)
        {
            return Ok(_workoutManager.EditWorkoutInCollection(newWorkout));
        }
    }



}
