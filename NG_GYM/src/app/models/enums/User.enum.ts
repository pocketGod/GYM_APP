export enum DifficultyLevels {
    Beginner = 0,
    Intermediate = 1,
    Advanced = 2
}

export const DifficultyLevelsLabels: { [key in DifficultyLevels]: string } = {
    [DifficultyLevels.Beginner]: 'Beginner',
    [DifficultyLevels.Intermediate]: 'Intermediate',
    [DifficultyLevels.Advanced]: 'Advanced'
};