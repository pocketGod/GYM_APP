using GYM_MODELS.DB;
using MongoDB.Driver;

namespace GYM_LOGICS.Services
{
    public class ExcerciseService
    {
        private readonly string _collectionName = "Excercises";
        private readonly IMongoCollection<ExerciseDBRecord> _exercises;

        public ExcerciseService(IMongoDatabase database)
        {
            _exercises = database.GetCollection<ExerciseDBRecord>(_collectionName);
        }

        public List<ExerciseDBRecord> GetAllExcercises()
        {
            return _exercises.Find(excercise => true).ToList();
        }

        public ExerciseDBRecord? GetFullExcercise(string excID)
        {
            return _exercises.Find((exc)=> exc._id == excID)?.FirstOrDefault();
        }

    }

}
