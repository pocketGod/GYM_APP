using GYM_LOGICS.Services;
using GYM_MODELS.Client;
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


        public Task<ExerciseByMuscleResponse> GetExercisesByTargetMuscle(Muscles targetMuscle)
        {
            return Task.FromResult(_exerciseService.GetExercisesByTargetMuscle(targetMuscle));
        }


        #region temp for development convinience
        public Task<List<Workout>> GetAllWorkouts()
        {
            return Task.FromResult(_workoutService.GetAllWorkouts());
        }
        public Task<List<Exercise>> GetAllExercises(){

            return Task.FromResult(_exerciseService.GetAllExercises());
        }
        #endregion
    }
}
