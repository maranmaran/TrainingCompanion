import { ExerciseType } from './exercise-type.model';

export class PersonalBest {
  id: string;
  value: number;
  dateAchieved: Date;
  bodyweight?: number;
  wilksScore: number;
  ipfPoints: number;

  exerciseTypeId: string;
  exerciseType: ExerciseType;
}
