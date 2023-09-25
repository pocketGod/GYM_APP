import { Muscles } from "../enums/Anatomy.enum";
import { EquipmentTypes } from "../enums/Gym.enum";
import { DifficultyLevels } from "../enums/User.enum";

export interface Exercise {
    id: string;
    name: string;
    imageUrl: string;
    targetMuscle: Muscles;
    includedMuscles: Muscles[];
    equipment: EquipmentTypes;
    possibleEquipments: EquipmentTypes[];
    difficulty: DifficultyLevels;
}