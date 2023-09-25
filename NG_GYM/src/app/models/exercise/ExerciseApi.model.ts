import { Exercise } from "./Exercise.model";

export interface ExerciseByMuscleResponse {
    target: Exercise[];
    included: Exercise[];
}