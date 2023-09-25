import { WorkoutTypes } from "../enums/Workout.enum";
import { Exercise } from "../exercise/Exercise.model";
import { ExerciseSet } from "../exercise/ExerciseSet.model";

export interface Workout {
    id: string;
    name: string;
    workoutType: WorkoutTypes;
    ownerUserId: string;
    exercises: WorkoutExercise[];
}

export interface WorkoutExercise {
    exercise: Exercise;
    sets: ExerciseSet[];
}