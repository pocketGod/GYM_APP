using GYM_MODELS.DB;
using MongoDB.Driver;

namespace GYM_LOGICS.Services
{
    public class ExerciseService
    {
        private readonly string _collectionName = "Excercises";
        private readonly IMongoCollection<ExerciseDBRecord> _exercises;

        public ExerciseService(IMongoDatabase database)
        {
            _exercises = database.GetCollection<ExerciseDBRecord>(_collectionName);
        }

        public List<ExerciseDBRecord> GetAllExercises()
        {
            return _exercises.Find(exercise => true).ToList();
        }

        public ExerciseDBRecord GetFullExercise(string exeID)
        {
            var exe = _exercises.Find((exe)=> exe._id == exeID);

            if (exe is null || exe.Count() == 0) {
                //invalid ID
            }

            return exe.FirstOrDefault();
        }

    }

}
