export class CreateTrainingProgramRequest {

    constructor(data: Partial<CreateTrainingProgramRequest>) {
        Object.assign(this, data);
    }

    creatorId: string;
    name: string;
    description: string;
    image: string;
}