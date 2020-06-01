import { BlockDurationType } from 'src/server-models/entities/training-program.model';

export class CreateTrainingProgramRequest {

    constructor(data: Partial<CreateTrainingProgramRequest>) {
        Object.assign(this, data);
    }

    creatorId: string;
    name: string;
    description: string;
    image: string;
}

export class CreateTrainingBlockRequest {

    constructor(data: Partial<CreateTrainingBlockRequest>) {
        Object.assign(this, data);
    }

    trainingProgramId: string;
    name: string;
    order: number;
    description: string;
    durationType: BlockDurationType;
    duration: number;
}
