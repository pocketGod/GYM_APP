using GYM_MODELS.Enums.Anatomy;
using GYM_MODELS.Enums.Common;
using GYM_MODELS.Enums.Gym;
using GYM_MODELS.Enums.Workout;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GYM_MODELS.DB
{
    public class ExerciseDBRecord : BaseDBRecord
    {
        /// <summary>
        /// Exercise Name (Benchpress / Deadlift / etc...)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Exercise Example Image URL
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Targeted muscle
        /// </summary>
        public Muscles TargetMuscle { get; set; }

        /// <summary>
        /// Included muscles
        /// </summary>
        public List<Muscles> IncludedMuscles { get; set; }

        /// <summary>
        /// Equipment required
        /// </summary>
        public EquipmentTypes Equipment { get; set; }

        /// <summary>
        /// Possible Equipment alternatives
        /// </summary>
        public List<EquipmentTypes> PossibleEquipment { get; set; }

        /// <summary>
        /// Difficulty level
        /// </summary>
        public DifficultyLevels Difficulty { get; set; }

    }

    public class InternalWorkoutExerciseDBRecord : BaseDBRecord
    {
        /// <summary>
        /// Refrence to Exercise ID in Exercise Collection
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string ID { get; set; }

        /// <summary>
        /// Assigned Sets For This Exercise
        /// </summary>
        public List<ExerciseSetDBRecord> Sets { get; set; }
    }
}