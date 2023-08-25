using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GYM_MODELS.Enums.Workout;
using GYM_MODELS.Enums.User;

namespace GYM_MODELS.DB
{
    public class WorkoutDBRecord : BaseDBRecord
    {
        /// <summary>
        /// Exercise name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Workout type (Full Body, Hands + Abs, etc...)
        /// </summary>
        public WorkoutTypes WorkoutType { get; set; }

        /// <summary>
        /// User ID Of Workout Creator
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string OwnerUserId { get; set; }

        /// <summary>
        /// Exercises Composing The Workout
        /// </summary>
        public List<InternalWorkoutExerciseDBRecord> Exercises { get; set; }

    }

    public class WorkoutPerformanceDBRecord : BaseDBRecord
    {
        /// <summary>
        /// Workout Time In Minutes (list of recorded values)
        /// </summary>
        public List<int> Duration { get; set; }

        /// <summary>
        /// Reference to the workout
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string WorkoutId { get; set; }

        /// <summary>
        /// List of performed exercises
        /// </summary>
        public List<ExerciseSetPerformanceDBRecord> PerformedExercises { get; set; }


        /// <summary>
        /// User's feelings after the workout (e.g., energized, tired)
        /// </summary>
        public UserFeedback Feedback { get; set; }
    }
}
