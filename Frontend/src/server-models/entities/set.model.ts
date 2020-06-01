import { Time } from '@angular/common';
import { Guid } from 'guid-typescript';
import { Exercise } from 'src/server-models/entities/exercise.model';

export class Set {

  id: string = Guid.EMPTY;

  // // strength training
  weight: number = 0;
  rpe: number = 8;
  rir: number = 2;
  reps: number = 0;
  percentage: number = 0;
  maxUsedForPercentage: number;

  // endurance
  time: Time;
  distance: number; // in meters
  power: number; // watts average

  // // if it can be calculated for statistics
  intensity: string;
  volume: number = 0;
  projectedMax: number = 0;

  // // velocity based
  averageVelocity: string;

  exerciseId: string;
  exercise: Exercise;

}
