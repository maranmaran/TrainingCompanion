import { ApplicationUser } from './application-user.model';
import { Exercise } from './exercise.model';
import { MediaFile } from './media-file.model';
import { TrainingBlockDay, TrainingProgram } from './training-program.model';

export class Training {
    id: string;
    dateTrained: Date;
    note: string;
    coachNote: string;
    noteRead: boolean;
    trainingProgramName: string;
    trainingProgramDay?: number;

    exercises: Exercise[];
    media: MediaFile[];

    applicationUserId: string;
    applicationUser: ApplicationUser;

    trainingProgramId: string;
    trainingProgram: TrainingProgram;

    trainingBlockDayId: string;
    trainingBlockDay: TrainingBlockDay;
}
