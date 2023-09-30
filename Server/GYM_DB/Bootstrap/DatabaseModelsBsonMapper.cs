using MongoDB.Bson.Serialization;
using GYM_MODELS.DB;

namespace GYM_DB.Bootstrap
{
    public static class DatabaseModelsBsonMapper
    {
        public static void Initialize()
        {

            BsonSerializer.RegisterSerializer(new WorkoutPlanInnerWorkoutDBRecordSerializer());


            BsonClassMap.RegisterClassMap<BaseDBRecord>(cm =>
            {
                cm.AutoMap();
                cm.SetIsRootClass(true);
            });

            BsonClassMap.RegisterClassMap<WorkoutPlanDBRecord>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<WorkoutPlanInnerWorkoutDBRecord>(cm =>
            {
                cm.AutoMap();
                cm.SetIgnoreExtraElements(true);
            });

        }

    }
}
