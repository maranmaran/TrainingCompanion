import { Time } from '@angular/common';

export class Set {
    id: string;
    weight: number;
    reps: number;
    time: Time;
    rpe: number;
    rir: number;
    intensity: string;
    volume: number = 0;
    averageVelocity: string;
    projectedMax: number = 0;

    exerciseId: string;
}
