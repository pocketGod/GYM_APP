export enum WorkoutTypes {
    FullBody = 0,
    UpperBody = 1,
    LowerBody = 2,
    ChestAndTriceps = 3,
    BackAndBiceps = 4,
    LegsAndShoulders = 5,
    Core = 6,
    Cardio = 7,
    StrengthTraining = 8,
    HighIntensityIntervalTraining = 9,
    Powerlifting = 10,
    CrossFit = 11,
    BodyweightExercises = 12,
    FlexibilityAndMobility = 13,
    CircuitTraining = 14,
    YogaAndPilates = 15
}

export const WorkoutTypesLabels: { [key in WorkoutTypes]: string } = {
    [WorkoutTypes.FullBody]: 'Full Body',
    [WorkoutTypes.UpperBody]: 'Upper Body',
    [WorkoutTypes.LowerBody]: 'Lower Body',
    [WorkoutTypes.ChestAndTriceps]: 'Chest and Triceps',
    [WorkoutTypes.BackAndBiceps]: 'Back and Biceps',
    [WorkoutTypes.LegsAndShoulders]: 'Legs and Shoulders',
    [WorkoutTypes.Core]: 'Core',
    [WorkoutTypes.Cardio]: 'Cardio',
    [WorkoutTypes.StrengthTraining]: 'Strength Training',
    [WorkoutTypes.HighIntensityIntervalTraining]: 'High Intensity Interval Training',
    [WorkoutTypes.Powerlifting]: 'Power Lifting',
    [WorkoutTypes.CrossFit]: 'Cross Fit',
    [WorkoutTypes.BodyweightExercises]: 'Body Weight Exercises',
    [WorkoutTypes.FlexibilityAndMobility]: 'Flexibility and Mobility',
    [WorkoutTypes.CircuitTraining]: 'Circuit Training',
    [WorkoutTypes.YogaAndPilates]: 'Yoga and Pilates'
};