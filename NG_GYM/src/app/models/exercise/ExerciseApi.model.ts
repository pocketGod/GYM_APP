import { Exercise } from "./Exercise.model";

export interface ExerciseByMuscleResponse {
    Target: Exercise[];
    Included: Exercise[];
}