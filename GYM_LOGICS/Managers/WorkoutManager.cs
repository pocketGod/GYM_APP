using GYM_LOGICS.Services;
using GYM_MODELS.DB;

namespace GYM_LOGICS.Managers
{
    public class WorkoutManager
    {
        private readonly ExcerciseService _excerciseService;
        public WorkoutManager(ExcerciseService excerciseService)
        {
            _excerciseService = excerciseService;
        }
        public Task<List<ExerciseDBRecord>> GetAllExcercises(){

            return Task.FromResult(_excerciseService.GetAllExcercises());
        }
    }
}
