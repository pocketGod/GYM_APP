using GYM_MODELS.Settings.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.Enums.Workout
{
    [EnumGroup("Workout")]
    [EnumTitle("Workout Types")]
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

    [EnumGroup("Workout")]
    [EnumTitle("Workout Cycles")]
    public enum WorkoutCycles
    {
        /// <summary>
        /// 1 Workout for each cycle
        /// </summary>
        Full = 0,

        /// <summary>
        /// 2 Different Workouts in a cycle
        /// </summary>
        AB = 1,

        /// <summary>
        /// 3 Different Workouts in a cycle
        /// </summary>
        ABC = 2,

        /// <summary>
        /// 4 Different Workouts in a cycle
        /// </summary>
        ABCD = 3,

        /// <summary>
        /// 5 Different Workouts in a cycle
        /// </summary>
        ABCDE = 4,

        /// <summary>
        /// 6 Different Workouts in a cycle
        /// </summary>
        ABCDEF = 5,

        /// <summary>
        /// A split between upper and lower body workouts
        /// </summary>
        UpperLowerSplit = 6,

        /// <summary>
        /// Workouts focusing only on specific muscle groups
        /// </summary>
        MuscleGroupFocus = 7,

        /// <summary>
        /// Workouts that alternate between strength and cardio
        /// </summary>
        StrengthCardio = 8,

        /// <summary>
        /// A recovery workout in the cycle
        /// </summary>
        Recovery = 9,

        /// <summary>
        /// A cycle that focuses on endurance
        /// </summary>
        Endurance = 10,

        /// <summary>
        /// A cycle that focuses on flexibility
        /// </summary>
        Flexibility = 11,

        /// <summary>
        /// A cycle that focuses on high-intensity interval training
        /// </summary>
        HIIT = 12,

        /// <summary>
        /// A cycle focused on plyometric exercises
        /// </summary>
        Plyometrics = 13,

        /// <summary>
        /// A cycle focused on core strengthening
        /// </summary>
        CoreStrengthening = 14
    }

    [EnumGroup("Workout")]
    [EnumTitle("Workout Goals")]
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
