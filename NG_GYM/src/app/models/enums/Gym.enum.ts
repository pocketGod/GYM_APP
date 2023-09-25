export enum EquipmentTypes {
    Bodyweight = 0,
    Dumbbells = 1,
    Barbell = 2,
    Kettlebell = 3,
    ResistanceBands = 4,
    Machines = 5,
    ExerciseBall = 6,
    Cables = 7
}

export const EquipmentTypesLabels: { [key in EquipmentTypes]: string } = {
    [EquipmentTypes.Bodyweight]: 'Bodyweight',
    [EquipmentTypes.Dumbbells]: 'Dumbbells',
    [EquipmentTypes.Barbell]: 'Barbell',
    [EquipmentTypes.Kettlebell]: 'Kettlebell',
    [EquipmentTypes.ResistanceBands]: 'Resistance Bands',
    [EquipmentTypes.Machines]: 'Machines',
    [EquipmentTypes.ExerciseBall]: 'Exercise Ball',
    [EquipmentTypes.Cables]: 'Cables'
};