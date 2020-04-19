import { ApplicationUser } from './application-user.model';
import { Training } from './training.model';

export class TrainingProgram {
    id: string;
    name: string;
    description: string;
    imageUrl: string;
    imageFtpFilePath: string;

    creatorId: string;
    creator: ApplicationUser;

    trainingBlocks: TrainingBlock[];
    users: TrainingProgramUser[];
}

export class TrainingProgramUser {
    id: string;
    startedOn: Date;
    endedOn: Date;
    isActive = !!this.endedOn;

    trainingProgramId: string;
    trainingProgram: TrainingProgram;

    applicationUserId: string;
    user: ApplicationUser;
}

export class TrainingBlock {
    id: string;
    name: string;
    description: string;
    durationInDays: number;
    days: TrainingBlockDay[]

    trainingProgramId: string;
    trainingProgram: TrainingProgram;
}

export class TrainingBlockDay {
    id: string;
    restDay: boolean;
    trainings: Training[]
}
