using GYM_LOGICS.Builders;
using GYM_MODELS.Client;
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
        private readonly WorkoutBuilder _workoutBuilder;

        public WorkoutService(IMongoDatabase database, WorkoutBuilder workoutBuilder)
        {
            _workouts = database.GetCollection<WorkoutDBRecord>(_collectionName);
            _workoutBuilder = workoutBuilder;
        }


        public List<Workout> GetAllWorkouts()
        {
            var dbRecords = _workouts.Find(workout => true).ToList();
            return dbRecords.Select(_workoutBuilder.Build).ToList();
        }
    }
}
