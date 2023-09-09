import { Exercise } from "../exercise/Exercise.model";
import { EnumPropertiesModel } from "../properties/PropertiesEnums.model";

export interface WorkoutCreationPropertiesResponse {
    WorkoutProperties: EnumPropertiesModel[];
    Exercises: { [key: string]: Exercise[] }[];
}