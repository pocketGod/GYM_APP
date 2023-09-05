using GYM_LOGICS.Services;
using GYM_MODELS.Client;
using GYM_MODELS.Client.WorkoutBuilder;
using GYM_MODELS.Enums.Anatomy;

namespace GYM_LOGICS.Managers
{
    public class WorkoutManager
    {
        private readonly ExerciseService _exerciseService;
        private readonly WorkoutService _workoutService;
        public WorkoutManager(WorkoutService workoutService, ExerciseService exerciseService)
        {
            _workoutService = workoutService;
            _exerciseService = exerciseService;
        }


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


        /// <summary>
        /// Asynchronously retrieves properties required for building a workout.
        /// </summary>
        /// <returns>A Task containing a response object with necessary properties for building a workout.</returns>
        public Task<WorkoutBuilderPropertiesResponse> GetWorkoutBuilderProperties()
        {
            return Task.FromResult(_workoutService.GetWorkoutBuildingProperties());
        }  
    }
}
