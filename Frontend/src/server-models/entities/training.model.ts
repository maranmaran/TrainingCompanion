import { MediaFile } from './media-file.model';
import { ApplicationUser } from './application-user.model';
import { Exercise } from './exercise.model';
import { TrainingProgram, TrainingBlockDay } from './training-program.model';

export class Training {
    id: string;
    dateTrained: Date;
    note: string;
    coachNote: string;
    noteRead: boolean;
    applicationUserId: string;
    applicationUser: ApplicationUser;
    exercises: Exercise[];
    media: MediaFile[];

    trainingProgramId: string;
    trainingProgram: TrainingProgram;

    trainingBlockDayId: string;
    trainingBlockDay: TrainingBlockDay;
}
