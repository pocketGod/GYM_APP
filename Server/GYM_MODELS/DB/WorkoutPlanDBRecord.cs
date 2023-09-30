using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GYM_MODELS.DB
{
    public class WorkoutPlanDBRecord : BaseDBRecord
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string OwnerUserId { get; set; }
        public string PlanName { get; set; }
        public List<WorkoutPlanInnerWorkoutDBRecord> Workouts { get; set; }
    }

    public class WorkoutPlanInnerWorkoutDBRecord
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime LastRecord { get; set; }
    }




}
