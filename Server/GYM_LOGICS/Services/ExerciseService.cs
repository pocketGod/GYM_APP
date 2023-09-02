using GYM_LOGICS.Builders;
using GYM_MODELS.Client;
using GYM_MODELS.DB;
using GYM_MODELS.Enums.Anatomy;
using MongoDB.Driver;

namespace GYM_LOGICS.Services
{
    public class ExerciseService
    {
        private readonly string _collectionName = "Excercises";
        private readonly IMongoCollection<ExerciseDBRecord> _exercises;
        private readonly ExerciseBuilder _exeBuilder;

        public ExerciseService(IMongoDatabase database, ExerciseBuilder exeBuilder)
        {
            _exercises = database.GetCollection<ExerciseDBRecord>(_collectionName); //temporary - only for development convinience
            _exeBuilder = exeBuilder;
        }

        public List<Exercise> GetAllExercises()
        {
            var dbRecords = _exercises.Find(exe => true).ToList();
            return dbRecords.Select(_exeBuilder.Build).ToList();
        }

        public ExerciseByMuscleResponse GetExercisesByTargetMuscle(Muscles targetMuscle)
        {

            // Get exercises where TargetMuscle matches the input
            var targetMuscleExercises = _exercises
                .Find(exe => exe.TargetMuscle == targetMuscle)
                .ToList()
                .Select(_exeBuilder.Build);

            // Get exercises where targetMuscle is in IncludedMuscles
            var includedMuscleExercises = _exercises
                .Find(exe => exe.IncludedMuscles.Contains(targetMuscle))
                .ToList()
                .Select(_exeBuilder.Build)
                .Where(included => !targetMuscleExercises.Any(target => target.Id == included.Id))
                .ToList();

            return new ExerciseByMuscleResponse
            {
                Target = targetMuscleExercises.ToList(),
                Included = includedMuscleExercises
            };

        }



        public Exercise GetFullExerciseByID(string exeID)
        {
            var exe = _exercises.Find(exe => exe._id == exeID).FirstOrDefault();

            if (exe == null)
            {
                // Handle invalid ID, maybe throw an exception or return null
                return null;
            }

            return _exeBuilder.Build(exe);
        }

    }
}
