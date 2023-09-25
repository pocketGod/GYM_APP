export enum MeasurementUnits {
    Kilograms = 0,
    Pounds = 1,
    Meters = 2,
    Feet = 3,
    Inches = 4,
    Centimeters = 5,
    Millimeters = 6
}

export const MeasurementUnitsLabels: { [key in MeasurementUnits]: string } = {
    [MeasurementUnits.Kilograms]: 'Kilograms',
    [MeasurementUnits.Pounds]: 'Pounds',
    [MeasurementUnits.Meters]: 'Meters',
    [MeasurementUnits.Feet]: 'Feet',
    [MeasurementUnits.Inches]: 'Inches',
    [MeasurementUnits.Centimeters]: 'Centimeters',
    [MeasurementUnits.Millimeters]: 'Millimeters'
};