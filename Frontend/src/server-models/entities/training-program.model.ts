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
  endedOn: Date = null;
  isActive = !!this.endedOn;

  trainingProgramId: string;
  trainingProgram: TrainingProgram;

  applicationUserId: string;
  user: ApplicationUser;
}

export class TrainingBlock {

  constructor(data: Partial<TrainingBlock>) {
    Object.assign(this, data);
  }

  id: string;
  order: number;
  name: string;
  description: string;

  durationType: BlockDurationType = BlockDurationType.Weeks;
  duration: number;

  days: TrainingBlockDay[]

  trainingProgramId: string;
  trainingProgram: TrainingProgram;
}

export enum BlockDurationType {
  Weeks = 'Weeks',
  Days = 'Days'
}

export class TrainingBlockDay {
  id: string;
  order: number;
  restDay: boolean;
  modified: boolean;
  trainings: Training[]
}
