using GYM_MODELS.DB;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_LOGICS.Services
{
    public class WorkoutService
    {
        private readonly string _collectionName = "Workouts";
        private readonly IMongoCollection<WorkoutDBRecord> _workouts;

        public WorkoutService(IMongoDatabase database)
        {
            _workouts = database.GetCollection<WorkoutDBRecord>(_collectionName);
        }


        public List<WorkoutDBRecord> GetAllWorkouts()
        {
            return _workouts.Find(exe => true).ToList();
        }
    }
}
