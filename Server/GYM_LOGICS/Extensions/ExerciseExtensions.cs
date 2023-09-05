using GYM_MODELS.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_LOGICS.Extensions
{
    public static class ExerciseExtensions
    {
        public static List<Dictionary<string, List<Exercise>>> GroupExercisesByTargetMuscle(this List<Exercise> exercises)
        {
            return exercises.GroupBy(e => e.TargetMuscle)
                                           .Select(g => new Dictionary<string, List<Exercise>>
                                           {
                                           { g.Key.ToString(), g.ToList() }
                                           })
                                           .ToList();
        }
    }
}
