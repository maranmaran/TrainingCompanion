import { Time } from '@angular/common';

export class Set {
    id: string;
    weight: number = 0;
    reps: number = 0;
    time: Time;
    rpe: number = 0;
    intensity: string;
    volume: number = 0;
    averageVelocity: string;
    projectedMax: number = 0;

    exerciseId: string;
}
