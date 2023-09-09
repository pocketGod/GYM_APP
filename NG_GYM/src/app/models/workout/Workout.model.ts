import { WorkoutTypes } from "../enums/Workout.enum";
import { Exercise } from "../exercise/Exercise.model";
import { ExerciseSet } from "../exercise/ExerciseSet.model";

export interface Workout {
    Id: string;
    Name: string;
    WorkoutType: WorkoutTypes;
    OwnerUserId: string;
    Exercises: WorkoutExercise[];
}

export interface WorkoutExercise {
    Exercise: Exercise;
    Sets: ExerciseSet[];
}