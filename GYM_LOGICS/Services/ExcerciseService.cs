using GYM_MODELS.DB;
using MongoDB.Driver;

namespace GYM_LOGICS.Services
{
    public class ExcerciseService
    {
        private readonly IMongoCollection<ExcerciseDBRecord> _excercises;

        public ExcerciseService(IMongoDatabase database)
        {
            _excercises = database.GetCollection<ExcerciseDBRecord>("Excercises");
        }

        public List<ExcerciseDBRecord> GetExcercises() => _excercises.Find(excercise => true).ToList();

    }

}
