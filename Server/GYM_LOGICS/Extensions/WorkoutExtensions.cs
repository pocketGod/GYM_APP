using GYM_MODELS.Client.WorkoutCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_LOGICS.Extensions
{
    public static class WorkoutExtensions
    {
        public static bool IsNewWorkoutValid(this NewWorkoutSchema schema, bool isNewWorkout = true)
        {
            // Check if there are exercises
            if (schema.Exercises == null || !schema.Exercises.Any())
            {
                return false;
            }

            // check if not updating an existing workout and if a workout id is set
            if (!isNewWorkout && !string.IsNullOrEmpty(schema.WorkoutId))
            {
                return false;
            }

            // Check if each exercise has at least one set
            if (schema.Exercises.Any(exercise => exercise.Sets == null || !exercise.Sets.Any()))
            {
                return false;
            }

            // Check if each exercise with more than one set has unique "Order" values for those sets
            if (schema.Exercises.Any(exercise => exercise.Sets.Count > 1 && !HasUniqueOrder(exercise.Sets)))
            {
                return false;
            }

            return true;
        }

        private static bool HasUniqueOrder(List<NewWorkoutExerciseSetSchema> sets)
        {
            return sets.Select(s => s.Order).Distinct().Count() == sets.Count;
        }
    }
}
