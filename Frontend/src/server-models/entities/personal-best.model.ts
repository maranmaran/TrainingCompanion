import { ExerciseType } from './exercise-type.model';

export class PersonalBest {
  id: string;
  value: number;
  dateAchieved: Date;
  bodyweight: number;

  //reps watts distance time
  // depends on exercise type..
  reps?: number;
  watts?: number;
  distance?: number;
  time?: number;

  wilksScore?: number;
  ipfPoints?: number;

  // meaning projected from app itself
  // false if user inserted this PR
  systemCalculated: boolean;

  exerciseTypeId: string;
  exerciseType: ExerciseType;
}
