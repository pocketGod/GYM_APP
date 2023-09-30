using GYM_LOGICS.Services;
using GYM_MODELS.Client;
using GYM_MODELS.DB;

namespace GYM_LOGICS.Builders
{
    public class WorkoutPlanBuilder
    {
        private readonly WorkoutService _workoutService;
        public WorkoutPlanBuilder(WorkoutService workoutService)
        {
            _workoutService = workoutService;
        }

        public WorkoutPlan BuildForClient(WorkoutPlanDBRecord dbRecord)
        {
            return new WorkoutPlan()
            {
                name = dbRecord.PlanName,
                workouts = dbRecord.Workouts.Select(wo =>
                {

                    return new WorkoutPlanWorkout()
                    {
                        workout = _workoutService.GetWorkoutById(wo.Id.ToString()),
                        lastRecord = wo.LastRecord
                    };

                }).ToList()
            };
        }
    }
}
