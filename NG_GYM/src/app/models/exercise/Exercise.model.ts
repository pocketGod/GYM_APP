import { Muscles } from "../enums/Anatomy.enum";
import { EquipmentTypes } from "../enums/Gym.enum";
import { DifficultyLevels } from "../enums/User.enum";

export interface Exercise {
    Id: string;
    Name: string;
    ImageUrl: string;
    TargetMuscle: Muscles;
    IncludedMuscles: Muscles[];
    Equipment: EquipmentTypes;
    PossibleEquipments: EquipmentTypes[];
    Difficulty: DifficultyLevels;
}