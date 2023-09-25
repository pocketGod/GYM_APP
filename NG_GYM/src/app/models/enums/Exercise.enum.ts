export enum ExerciseSetTypes {
    Regular = 0,
    SuperSet = 1,
    CompoundSet = 2,
    DropSet = 3,
    FailureSet = 4,
    TimedSet = 5,
    PauseSet = 6,
    PyramidSet = 7
}

export const ExerciseSetTypesLabels: { [key in ExerciseSetTypes]: string } = {
    [ExerciseSetTypes.Regular]: 'Regular',
    [ExerciseSetTypes.SuperSet]: 'Super Set',
    [ExerciseSetTypes.CompoundSet]: 'Compound Set',
    [ExerciseSetTypes.DropSet]: 'Drop Set',
    [ExerciseSetTypes.FailureSet]: 'Failure Set',
    [ExerciseSetTypes.TimedSet]: 'Timed Set',
    [ExerciseSetTypes.PauseSet]: 'Pause Set',
    [ExerciseSetTypes.PyramidSet]: 'Pyramid Set'
};