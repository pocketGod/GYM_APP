using GYM_MODELS.Enums.Workout;
using GYM_MODELS.Settings.Properties;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using GYM_MODELS.Enums.Common;
using GYM_MODELS.Enums.Exercise;

namespace GYM_MODELS.Client.WorkoutCreator
{
    /// <summary>
    /// Initial response containing the clients properties and options for builing a workout
    /// </summary>
   public class WorkoutCreatorPropertiesResponse
    {
        public List<EnumPropertiesModel> WorkoutProperties { get; set; }

        public List<Dictionary<string, List<Exercise>>> Exercises { get; set; }
    }


    public class NewWorkoutSchema
    {
        /// <summary>
        /// Workout Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Workout Type
        /// </summary>
        public WorkoutTypes WorkoutType { get; set; }

        /// <summary>
        /// List of exercises
        /// </summary>
        public List<NewWorkoutExerciseSchema> Exercises { get; set; }

        /// <summary>
        /// Reference to an existing workout (for workout update logics)
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string WorkoutId { get; set; }
    }

    public class NewWorkoutExerciseSchema
    {
        /// <summary>
        /// Reference to the Exercise ID
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        public List<NewWorkoutExerciseSetSchema> Sets { get; set; }

    }

    public class NewWorkoutExerciseSetSchema
    {
        /// <summary>
        /// Order Of This Set Between Other Sets Of The Same Exercise
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Amount Of Reps
        /// </summary>
        public int Reps { get; set; }

        /// <summary>
        /// Set type (Regular, SuperSet, etc...)
        /// </summary>
        public ExerciseSetTypes SetType { get; set; }

    }
}
