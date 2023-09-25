import { Exercise } from "../exercise/Exercise.model";
import { EnumPropertiesModel } from "../properties/PropertiesEnums.model";

export interface WorkoutCreationPropertiesResponse {
    workoutProperties: EnumPropertiesModel[];
    exercises: { [key: string]: Exercise[] }[];
}