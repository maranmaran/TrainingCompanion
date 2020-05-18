import { Time } from '@angular/common';
import { Guid } from 'guid-typescript';

export class Set {

    constructor() {

    }

    id: string = Guid.EMPTY;
    weight: number = 0;
    reps: number = 0;
    time: Time;
    rpe: number = 8;
    rir: number = 2;
    intensity: string;
    volume: number = 0;
    averageVelocity: string;
    projectedMax: number = 0;

    exerciseId: string;
}
