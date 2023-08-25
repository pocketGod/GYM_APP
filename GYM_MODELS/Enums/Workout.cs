using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.Enums.Workout
{
    public enum WorkoutTypes
    {
        /// <summary>
        /// A complete body workout
        /// </summary>
        FullBody = 0,

        /// <summary>
        /// Focuses on arms, chest, back, and shoulders
        /// </summary>
        UpperBody = 1,

        /// <summary>
        /// Focuses on legs and glutes
        /// </summary>
        LowerBody = 2,

        /// <summary>
        /// Targets the chest and triceps muscles
        /// </summary>
        ChestAndTriceps = 3,

        /// <summary>
        /// Targets the back and biceps muscles
        /// </summary>
        BackAndBiceps = 4,

        /// <summary>
        /// Targets legs and shoulder muscles
        /// </summary>
        LegsAndShoulders = 5,

        /// <summary>
        /// Focuses on abdominal muscles
        /// </summary>
        Core = 6,

        /// <summary>
        /// Cardiovascular exercises
        /// </summary>
        Cardio = 7,

        /// <summary>
        /// Weightlifting and resistance exercises
        /// </summary>
        StrengthTraining = 8,

        /// <summary>
        /// Short bursts of intense exercise
        /// </summary>
        HighIntensityIntervalTraining = 9,

        /// <summary>
        /// Focuses on squat, bench press, and deadlift
        /// </summary>
        Powerlifting = 10,

        /// <summary>
        /// A branded fitness regimen
        /// </summary>
        CrossFit = 11,

        /// <summary>
        /// Exercises that use body weight as resistance
        /// </summary>
        BodyweightExercises = 12,

        /// <summary>
        /// Focuses on stretching and movement
        /// </summary>
        FlexibilityAndMobility = 13,

        /// <summary>
        /// A series of exercises performed in succession
        /// </summary>
        CircuitTraining = 14,

        /// <summary>
        /// Mind-body exercises focusing on strength and flexibility
        /// </summary>
        YogaAndPilates = 15
    }
    public enum WorkoutGoals
    {
        /// <summary>
        /// Building muscle mass
        /// </summary>
        MuscleGain = 0,

        /// <summary>
        /// Reducing body fat
        /// </summary>
        WeightLoss = 1,

        /// <summary>
        /// Improving cardiovascular health
        /// </summary>
        CardioHealth = 2,

        /// <summary>
        /// Enhancing flexibility and mobility
        /// </summary>
        Flexibility = 3,

        /// <summary>
        /// Increasing overall strength
        /// </summary>
        Strength = 4,

        /// <summary>
        /// Enhancing endurance and stamina
        /// </summary>
        Endurance = 5,

        /// <summary>
        /// Generally increasing one's health
        /// </summary>
        GeneralHealth = 6
    }
}
