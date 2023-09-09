import { MeasurementUnits } from "../enums/Common.enum";
import { ExerciseSetTypes } from "../enums/Exercise.enum";

export interface ExerciseSet {
    Order: number;
    Reps: number;
    SetType: ExerciseSetTypes;
    StarterMeasure: number;
    MeasureUnit: MeasurementUnits;
}