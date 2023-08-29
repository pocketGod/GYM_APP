using GYM_LOGICS.Services;
using GYM_MODELS.DB;

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
        public Task<List<ExerciseDBRecord>> GetAllExercises(){

            return Task.FromResult(_exerciseService.GetAllExercises());
        }

        public Task<List<WorkoutDBRecord>> GetAllWorkouts()
        {

            return Task.FromResult(_workoutService.GetAllWorkouts());
        }
    }
}
