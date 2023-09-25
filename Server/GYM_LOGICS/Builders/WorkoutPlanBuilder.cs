using GYM_LOGICS.Services;
using GYM_MODELS.Client;
using GYM_MODELS.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                workouts = dbRecord.Workouts.Select(woId => _workoutService.GetWorkoutById(woId.ToString())).ToList()
            };
        }
    }
}
