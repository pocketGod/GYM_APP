using GYM_DB.Repositories;
using GYM_LOGICS.Builders;
using GYM_MODELS.Client;
using GYM_MODELS.Enums.Anatomy;

namespace GYM_LOGICS.Services
{
    public class ExerciseService
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly ExerciseBuilder _exeBuilder;

        public ExerciseService(IExerciseRepository exerciseRepository, ExerciseBuilder exeBuilder)
        {
            _exerciseRepository = exerciseRepository;
            _exeBuilder = exeBuilder;
        }

        public List<Exercise> GetAllExercises()
        {
            var dbRecords = _exerciseRepository.GetAllExercises();
            return dbRecords.Select(_exeBuilder.Build).ToList();
        }

        public ExerciseByMuscleResponse GetExercisesByTargetMuscle(Muscles targetMuscle)
        {
            var dbRecords = _exerciseRepository.GetExercisesByTargetMuscle(targetMuscle);
            var exercises = dbRecords.Select(_exeBuilder.Build).ToList();

            var targetMuscleExercises = exercises.Where(exe => exe.TargetMuscle == targetMuscle).ToList();
            var includedMuscleExercises = exercises.Where(exe => exe.IncludedMuscles.Contains(targetMuscle)).ToList();

            return new ExerciseByMuscleResponse
            {
                Target = targetMuscleExercises,
                Included = includedMuscleExercises
            };
        }

        public Exercise GetFullExerciseByID(string exeID)
        {
            var dbRecord = _exerciseRepository.GetFullExerciseByID(exeID);
            return dbRecord == null ? null : _exeBuilder.Build(dbRecord);
        }
    }
}
