import { MeasurementUnits } from "../enums/Common.enum";
import { ExerciseSetTypes } from "../enums/Exercise.enum";

export interface ExerciseSet {
    order: number;
    reps: number;
    setType: ExerciseSetTypes;
    starterMeasure: number;
    measureUnit: MeasurementUnits;
}