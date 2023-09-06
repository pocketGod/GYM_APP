using GYM_MODELS.DB;
using GYM_MODELS.Enums.Workout;

namespace GYM_MODELS.Client
{
    public class Workout
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public WorkoutTypes WorkoutType { get; set; }
        public string OwnerUserId { get; set; }
        public List<WorkoutExercise> Exercises { get; set; }
    }

    public class WorkoutExercise
    {
        public Exercise Exercise { get; set; }
        public List<ExerciseSetDBRecord> Sets { get; set; }
    }




}
