
export class UpdateTrainingProgramRequest {
    constructor(data: Partial<UpdateTrainingProgramRequest>) {
        Object.assign(this, data);
    }

    id: string;
    name: string;
    description: string;
    image: string;
}


export class UpdateTrainingBlockRequest {

  constructor(data: Partial<UpdateTrainingBlockRequest>) {
      Object.assign(this, data);
  }

  id: string;
  name: string;
  description: string;
  durationInDays: number;
}
