
using GYM_DB.Repositories.Base;
using GYM_MODELS.DB;
using GYM_MODELS.Enums.Anatomy;
using MongoDB.Driver;

namespace GYM_DB.Repositories
{
    public interface IExerciseRepository
    {
        ExerciseDBRecord GetFullExerciseByID(string exeID);
        List<ExerciseDBRecord> GetAllExercises();
        List<ExerciseDBRecord> GetExercisesByTargetMuscle(Muscles targetMuscle);
    }

    public class ExerciseRepository : Repository<ExerciseDBRecord>, IExerciseRepository
    {
        public ExerciseRepository(IMongoDatabase database) : base(database, "Excercises")
        {
        }

        public ExerciseDBRecord GetFullExerciseByID(string exeID)
        {
            var filter = Builders<ExerciseDBRecord>.Filter.Eq(exe => exe._id, exeID);
            return FindOne(filter);
        }

        public List<ExerciseDBRecord> GetAllExercises()
        {
            return FindAll();
        }

        public List<ExerciseDBRecord> GetExercisesByTargetMuscle(Muscles targetMuscle)
        {
            var filter = Builders<ExerciseDBRecord>.Filter.Eq(exe => exe.TargetMuscle, targetMuscle);
            return FindAll(filter);
        }
    }
}
