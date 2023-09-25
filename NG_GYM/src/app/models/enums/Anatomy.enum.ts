export enum Muscles {
    Biceps = 0,
    Triceps = 1,
    Chest = 2,
    UpperChest = 3,
    Back = 4,
    UpperBack = 5,
    LowerBack = 6,
    Shoulders = 7,
    Quads = 8,
    Hamstrings = 9,
    Abs = 10,
    Calves = 11
}

export const MusclesLabels: { [key in Muscles]: string } = {
    [Muscles.Biceps]: 'Biceps',
    [Muscles.Triceps]: 'Triceps',
    [Muscles.Chest]: 'Chest',
    [Muscles.UpperChest]: 'Upper Chest',
    [Muscles.Back]: 'Back',
    [Muscles.UpperBack]: 'Upper Back',
    [Muscles.LowerBack]: 'Lower Back',
    [Muscles.Shoulders]: 'Shoulders',
    [Muscles.Quads]: 'Quads',
    [Muscles.Hamstrings]: 'Hamstrings',
    [Muscles.Abs]: 'Abs',
    [Muscles.Calves]: 'Calves'
};