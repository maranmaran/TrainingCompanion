import { MediaFile } from 'src/server-models/entities/media-file.model';
import { ExerciseType } from './exercise-type.model';
import { Set } from './set.model';
import { Training } from './training.model';
export class Exercise {
    id: string;

    trainingId: string;
    training: Training;

    order: number;

    exerciseTypeId: string;
    exerciseType: ExerciseType;

    sets: Set[];
    media: MediaFile[];
}
