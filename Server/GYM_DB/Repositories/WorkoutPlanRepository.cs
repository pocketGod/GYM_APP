using GYM_DB.Repositories.Base;
using GYM_MODELS.DB;
using MongoDB.Driver;

namespace GYM_DB.Repositories
{
    public interface IWorkoutPlanRepository
    {
        List<WorkoutPlanDBRecord> GetPlansByOwner(string ownerId);
        WorkoutPlanDBRecord GetPlanById(string id);
        bool InsertOne(WorkoutPlanDBRecord record);
        bool ReplaceOne(string id, WorkoutPlanDBRecord updatedRecord);
    }

    public class WorkoutPlanRepository : Repository<WorkoutPlanDBRecord>, IWorkoutPlanRepository
    {
        public WorkoutPlanRepository(IMongoDatabase database) : base(database, "WO_Plans")
        {
        }

        public List<WorkoutPlanDBRecord> GetPlansByOwner(string ownerId)
        {
            var filter = Builders<WorkoutPlanDBRecord>.Filter.Eq(plan => plan.OwnerUserId, ownerId);
            return FindAll(filter);
        }


        public WorkoutPlanDBRecord GetPlanById(string id)
        {
            var filter = Builders<WorkoutPlanDBRecord>.Filter.Eq(plan => plan._id, id);
            return FindOne(filter);
        }

        public bool ReplaceOne(string id, WorkoutPlanDBRecord updatedRecord)
        {
            var filter = Builders<WorkoutPlanDBRecord>.Filter.Eq(plan => plan._id, id);
            return base.ReplaceOne(filter, updatedRecord);
        }
    }
}
