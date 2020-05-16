import { Time } from '@angular/common';
import { Guid } from 'guid-typescript';
import { Exercise } from './exercise.model';

export class Set {

    constructor() {

    }

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
