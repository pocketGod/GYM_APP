using MongoDB.Driver;
using GYM_MODELS.DB;
using System.Collections.Generic;
using GYM_DB.Repositories.Base;
using System;

namespace GYM_DB.Repositories
{
    public interface IWorkoutRepository
    {
        List<WorkoutDBRecord> GetWorkoutsByOwner(string ownerId);
        WorkoutDBRecord GetWorkoutById(string id);
        bool InsertOne(WorkoutDBRecord record);
        bool ReplaceOne(string id, WorkoutDBRecord updatedRecord);

    }

    public class WorkoutRepository : Repository<WorkoutDBRecord>, IWorkoutRepository
    {
        public WorkoutRepository(IMongoDatabase database) : base(database, "Workouts")
        {
        }

        public List<WorkoutDBRecord> GetWorkoutsByOwner(string ownerId)
        {
            var filter = Builders<WorkoutDBRecord>.Filter.Eq(workout => workout.OwnerUserId, ownerId);
            return FindAll(filter);
        }

        public WorkoutDBRecord GetWorkoutById(string id)
        {
            var filter = Builders<WorkoutDBRecord>.Filter.Eq(workout => workout._id, id);
            return FindOne(filter);
        }

        public bool ReplaceOne(string id, WorkoutDBRecord updatedRecord)
        {
            var filter = Builders<WorkoutDBRecord>.Filter.Eq(w => w._id, id);
            return base.ReplaceOne(filter, updatedRecord);
        }



    }
}
