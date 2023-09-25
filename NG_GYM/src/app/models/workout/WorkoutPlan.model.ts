import { Workout } from "./Workout.model";

export interface WorkoutPlan{
    name: string,
    workouts: Workout[]
}