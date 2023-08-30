using GYM_MODELS.Settings.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.Enums.Exercise
{
    [EnumGroup("Workout")]
    [EnumTitle("Exercise Set Types")]
    public enum ExerciseSetTypes
    {
        /// <summary>
        /// A regular set of exercises
        /// </summary>
        Regular = 0,

        /// <summary>
        /// A set that combines two or more exercises without rest
        /// </summary>
        SuperSet = 1,

        /// <summary>
        /// A set that targets the same muscle group with different exercises
        /// </summary>
        CompoundSet = 2,

        /// <summary>
        /// A set that starts with heavy weights and decreases the weight with each set
        /// </summary>
        DropSet = 3,

        /// <summary>
        /// A set performed with maximum effort or until failure
        /// </summary>
        FailureSet = 4,

        /// <summary>
        /// A set with exercises performed in a specific time frame
        /// </summary>
        TimedSet = 5,

        /// <summary>
        /// A set that includes pauses at specific points within the lift
        /// </summary>
        PauseSet = 6,

        /// <summary>
        /// A set that repeats a specific number of reps at different weights
        /// </summary>
        PyramidSet = 7
    }
}
