import { ExerciseSetTypes } from "../enums/Exercise.enum";
import { WorkoutTypes } from "../enums/Workout.enum";

export interface NewWorkout {
    Name: string;
    WorkoutType: WorkoutTypes;
    Exercises: NewWorkoutExercise[];
    WorkoutId: string;
}

export interface NewWorkoutExercise {
    ID: string;
    Sets: NewWorkoutExerciseSet[];
}

export interface NewWorkoutExerciseSet {
    Order: number;
    Reps: number;
    SetType: ExerciseSetTypes;
}
  
