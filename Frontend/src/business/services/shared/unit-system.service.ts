import { UnitSystem } from 'src/server-models/enums/unit-system.enum';

export const MASS_KG_LBS = 2.2046;

export function transformWeight(weight: number, unitSystem: UnitSystem): string {
    switch (unitSystem) {
        case UnitSystem.Metric: // this is by default
            return toMetric(weight) + ' kg';
        case UnitSystem.Imperial:
            return toImperial(weight) + ' lbs';
        default:
            throw new Error("No Unit system like the one specified");
    }
}

export function transformWeightToNumber(weight: number, unitSystem: UnitSystem = this.unitSystem): number {
    switch (unitSystem) {
        case UnitSystem.Metric: // this is by default
            return toMetric(weight);
        case UnitSystem.Imperial:
            return toImperial(weight);
        default:
            throw new Error("No Unit system like the one specified");
    }
}

export function toMetric(number: number): number {
    return number; // because default.. return same number
}

export function toImperial(number: number): number {
    return Math.round(number * MASS_KG_LBS * 100) / 100;
}
