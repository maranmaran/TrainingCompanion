import { Time } from '@angular/common';
import { Guid } from 'guid-typescript';

export class Set {
    id: string = Guid.EMPTY;
    weight: number;
    reps: number;
    time: Time;
    rpe: number = 8;
    rir: number = 2;
    intensity: string;
    volume: number = 0;
    averageVelocity: string;
    projectedMax: number = 0;

    exerciseId: string;
}
