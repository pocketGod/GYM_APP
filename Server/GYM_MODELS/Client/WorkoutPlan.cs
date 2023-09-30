using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.Client
{
    public class WorkoutPlan
    {
        public string name { get; set; }
        public List<WorkoutPlanWorkout> workouts { get; set; }
    }

    public class WorkoutPlanWorkout
    {
        public Workout workout { get; set; }
        public DateTime lastRecord { get; set; }
    }
}
