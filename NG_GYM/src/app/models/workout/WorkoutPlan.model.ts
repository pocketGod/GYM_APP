import { Workout } from "./Workout.model";

export interface WorkoutPlan{
    name: string,
    workouts: WorkoutPlanWorkout[]
}

export interface WorkoutPlanWorkout{
    workout: Workout,
    lastRecord: Date
}