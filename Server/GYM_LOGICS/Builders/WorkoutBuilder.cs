using GYM_LOGICS.Services;
using GYM_MODELS.Client;
using GYM_MODELS.Client.WorkoutCreator;
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

        public Workout BuildForClient(WorkoutDBRecord dbRecord)
        {
            if (dbRecord == null || dbRecord.Exercises == null)
            {
                return null;
            }

            List<string> exerciseIds = dbRecord.Exercises.Select(e => e.ID).ToList();
            Dictionary<string, Exercise> exercises = exerciseIds.Select(id => _exerciseService.GetFullExerciseByID(id))
                                        .Where(ex => ex != null)
                                        .ToDictionary(ex => ex.Id, ex => ex);

            Workout clientModel = new()
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

        public WorkoutDBRecord BuildNewWorkout(NewWorkoutSchema newWorkout, string userId)
        {
            return new WorkoutDBRecord
            {
                Name = newWorkout.Name,
                WorkoutType = newWorkout.WorkoutType,
                OwnerUserId = userId,
                Exercises = newWorkout.Exercises.Select(e => new InternalWorkoutExerciseDBRecord
                {
                    ID = e.ID,
                    Sets = e.Sets.Select(s => new ExerciseSetDBRecord
                    {
                        Order = s.Order,
                        Reps = s.Reps,
                        SetType = s.SetType,
                        MeasureUnit = GYM_MODELS.Enums.Common.MeasurementUnits.Kilograms
                    }).ToList()
                }).ToList()
            };
        }
    }
}
