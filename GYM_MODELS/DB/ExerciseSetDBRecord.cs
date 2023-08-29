using GYM_MODELS.Enums.Common;
using GYM_MODELS.Enums.Exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.DB
{
    public class ExerciseSetDBRecord 
    {
        /// <summary>
        /// Order Of This Set Between Other Sets Of The Same Exercise
        /// </summary>
        public int Order { get; set; }
        
        /// <summary>
        /// Amount Of Reps
        /// </summary>
        public int Reps { get; set; }

        /// <summary>
        /// Set type (Regular, SuperSet, etc...)
        /// </summary>
        public ExerciseSetTypes SetType { get; set; }

        /// <summary>
        /// Weight/Height to show if now last weight/height data is available
        /// </summary>
        public double StarterMeasure { get; set; }

        /// <summary>
        /// Weight/Height Measure unit
        /// </summary>
        public MeasurementUnits MeasureUnit { get; set; }
    }

    public class ExerciseSetPerformanceDBRecord : BaseDBRecord
    {
        /// <summary>
        /// Amount of reps performed
        /// </summary>
        public int ActualReps { get; set; }

        /// <summary>
        /// Actual Weight/Height performed
        /// </summary>
        public double ActualMeasure { get; set; }

        /// <summary>
        /// Measure Weight/Height unit
        /// </summary>
        public MeasurementUnits MeasureUnit { get; set; }

        /// <summary>
        /// Time taken to complete the set in seconds
        /// </summary>
        public int Time { get; set; }
    }

}
