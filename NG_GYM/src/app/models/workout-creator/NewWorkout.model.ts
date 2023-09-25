import { ExerciseSetTypes } from "../enums/Exercise.enum";
import { WorkoutTypes } from "../enums/Workout.enum";

export interface NewWorkout {
    name: string;
    workoutType: WorkoutTypes;
    exercises: NewWorkoutExercise[];
    workoutId: string;
}

export interface NewWorkoutExercise {
    id: string;
    sets: NewWorkoutExerciseSet[];
}

export interface NewWorkoutExerciseSet {
    order: number;
    reps: number;
    setType: ExerciseSetTypes;
}
  
