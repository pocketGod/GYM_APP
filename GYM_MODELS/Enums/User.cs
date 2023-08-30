using GYM_MODELS.Settings.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.Enums.User
{
    [EnumGroup("User")]
    [EnumTitle("User Feedback")]
    public enum UserFeedback
    {
        /// <summary>
        /// Unknown or not provided feedback
        /// </summary>
        Unknown = 0,

        /// <summary>
        /// Feeling energized and strong
        /// </summary>
        Energized = 1,

        /// <summary>
        /// Feeling fatigued or tired
        /// </summary>
        Tired = 2,

        /// <summary>
        /// Feeling satisfied with the workout
        /// </summary>
        Satisfied = 3,

        /// <summary>
        /// Feeling that the workout was too easy
        /// </summary>
        TooEasy = 4,

        /// <summary>
        /// Feeling that the workout was too hard
        /// </summary>
        TooHard = 5,

        /// <summary>
        /// Feeling indifferent or neutral about the workout
        /// </summary>
        Neutral = 6
    }
}
