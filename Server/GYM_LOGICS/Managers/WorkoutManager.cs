using GYM_LOGICS.Services;
using GYM_MODELS.Client;
using GYM_MODELS.Client.WorkoutCreator;
using GYM_MODELS.Enums.Anatomy;

namespace GYM_LOGICS.Managers
{
    public class WorkoutManager
    {
        private readonly ExerciseService _exerciseService;
        private readonly WorkoutPlanService _planService;
        private readonly WorkoutService _workoutService;
        public WorkoutManager(WorkoutService workoutService, ExerciseService exerciseService, WorkoutPlanService planService)
        {
            _workoutService = workoutService;
            _exerciseService = exerciseService;
            _planService = planService;
        }


        #region Data Retrieval Methods

        /// <summary>
        /// Asynchronously retrieves exercises based on the target muscle group.
        /// </summary>
        /// <param name="targetMuscle">The target muscle group for filtering exercises.</param>
        /// <returns>A Task containing a response object with exercises filtered by the target muscle.</returns>
        public Task<ExerciseByMuscleResponse> GetExercisesByTargetMuscle(Muscles targetMuscle)
        {
            return Task.FromResult(_exerciseService.GetExercisesByTargetMuscle(targetMuscle));
        }

        /// <summary>
        /// Asynchronously retrieves all workout plans associated with the current user.
        /// </summary>
        /// <returns>A Task containing a list of all workout plans for the current user.</returns>
        public Task<List<WorkoutPlan>> GetAllMyPlans()
        {
            return Task.FromResult(_planService.GetAllMyPlans());
        }


        /// <summary>
        /// Asynchronously retrieves all workouts associated with the current user.
        /// </summary>
        /// <returns>A Task containing a list of all workouts for the current user.</returns>
        public Task<List<Workout>> GetAllMyWorkouts()
        {
            return Task.FromResult(_workoutService.GetAllMyWorkouts());
        }

        /// <summary>
        /// Asynchronously retrieves all available exercises.
        /// </summary>
        /// <returns>A Task containing a list of all exercises.</returns>
        public Task<List<Exercise>> GetAllExercises(){

            return Task.FromResult(_exerciseService.GetAllExercises());
        }

        #endregion


        #region Workout Creator Methods


        /// <summary>
        /// Asynchronously adds a new workout to the DB
        /// </summary>
        /// <returns>A Task containing a bool indicating wether the new record was updated in the DB</returns>
        public Task<bool> AddNewWorkoutToCollection(NewWorkoutSchema newWorkout)
        {
            return Task.FromResult(_workoutService.AddNewWorkoutToCollection(newWorkout));
        }

        /// <summary>
        /// Asynchronously edits a workout in the DB
        /// </summary>
        /// <returns>A Task containing a bool indicating wether the new record was updated in the DB</returns>
        public Task<bool> EditWorkoutInCollection(NewWorkoutSchema newWorkout)
        {
            return Task.FromResult(_workoutService.EditWorkoutInCollection(newWorkout));
        }

        #endregion
    }
}
