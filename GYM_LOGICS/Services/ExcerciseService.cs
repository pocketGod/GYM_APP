using GYM_MODELS.DB;
using MongoDB.Driver;

namespace GYM_LOGICS.Services
{
    public class ExcerciseService
    {
        private readonly string _collectionName = "Excercises";
        private readonly IMongoCollection<ExcerciseDBRecord> _exercises;

        public ExcerciseService(IMongoDatabase database)
        {
            _exercises = database.GetCollection<ExcerciseDBRecord>(_collectionName);
        }

        public List<ExcerciseDBRecord> GetAllExcercises()
        {
            return _exercises.Find(excercise => true).ToList();
        }

        public ExcerciseDBRecord? GetFullExcercise(string excID)
        {
            return _exercises.Find((exc)=> exc._id == excID)?.FirstOrDefault();
        }

    }

}
