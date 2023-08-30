using GYM_MODELS.Settings.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.Enums.Anatomy
{
    [EnumGroup("Workout")]
    [EnumTitle("Muscle Groups")]
    public enum Muscles
    {
        /// <summary>
        /// Bicep muscles
        /// </summary>
        Biceps = 0,

        /// <summary>
        /// Tricep muscles
        /// </summary>
        Triceps = 1,

        /// <summary>
        /// Chest muscles
        /// </summary>
        Chest = 2,

        /// <summary>
        /// Upper Chest muscles
        /// </summary>
        UpperChest = 3,

        /// <summary>
        /// Back muscles
        /// </summary>
        Back = 4,

        /// <summary>
        /// UpperBack muscles
        /// </summary>
        UpperBack = 5,

        /// <summary>
        /// LowerBack muscles
        /// </summary>
        LowerBack = 6,

        /// <summary>
        /// Shoulder muscles
        /// </summary>
        Shoulders = 7,

        /// <summary>
        /// Quadricep muscles
        /// </summary>
        Quads = 8,

        /// <summary>
        /// Hamstring muscles
        /// </summary>
        Hamstrings = 9,

        /// <summary>
        /// Abdominal muscles
        /// </summary>
        Abs = 10,

        /// <summary>
        /// Calf muscles
        /// </summary>
        Calves = 11
    }
}
