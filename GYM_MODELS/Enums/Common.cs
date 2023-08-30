using GYM_MODELS.Settings.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.Enums.Common
{
    [EnumGroup("General")]
    [EnumTitle("Difficulty Levels")]
    public enum DifficultyLevels
    {
        /// <summary>
        /// Suitable for beginners
        /// </summary>
        Beginner = 0,

        /// <summary>
        /// Intermediate level
        /// </summary>
        Intermediate = 1,

        /// <summary>
        /// Challenging for advanced individuals
        /// </summary>
        Advanced = 2
    }

    [EnumGroup("General")]
    [EnumTitle("Measurement Units")]
    public enum MeasurementUnits
    {
        /// <summary>
        /// Kilograms
        /// </summary>
        Kilograms = 0,

        /// <summary>
        /// Pounds
        /// </summary>
        Pounds = 1,

        /// <summary>
        /// Meters
        /// </summary>
        Meters = 2,

        /// <summary>
        /// Feet
        /// </summary>
        Feet = 3,

        /// <summary>
        /// Inches
        /// </summary>
        Inches = 4,

        /// <summary>
        /// Centimeters
        /// </summary>
        Centimeters = 5,

        /// <summary>
        /// Millimeters
        /// </summary>
        Millimeters = 6,
    }
}
