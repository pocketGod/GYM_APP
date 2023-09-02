using GYM_LOGICS.Services;
using GYM_MODELS.Client;
using GYM_MODELS.DB;

namespace GYM_LOGICS.Builders
{
    public class WorkoutBuilder
    {
        private readonly ExerciseService _exerciseService;
        public WorkoutBuilder(ExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public Workout Build(WorkoutDBRecord dbRecord)
        {
            if (dbRecord == null || dbRecord.Exercises == null)
            {
                return null;
            }

            var exerciseIds = dbRecord.Exercises.Select(e => e.ID).ToList();
            var exercises = exerciseIds.Select(id => _exerciseService.GetFullExerciseByID(id))
                                        .Where(ex => ex != null)
                                        .ToDictionary(ex => ex.Id, ex => ex);

            var clientModel = new Workout
            {
                Id = dbRecord._id,
                Name = dbRecord.Name,
                WorkoutType = dbRecord.WorkoutType,
                OwnerUserId = dbRecord.OwnerUserId,
                Exercises = dbRecord.Exercises
                    .Where(e => exercises.ContainsKey(e.ID))  // Only include exercises that were found
                    .Select(e => new WorkoutExercise
                    {
                        Exercise = exercises[e.ID],
                        Sets = e.Sets
                    })
                    .ToList()
            };

            return clientModel;
        }
    }
}
