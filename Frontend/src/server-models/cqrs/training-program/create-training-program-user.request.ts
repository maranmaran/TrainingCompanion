export class CreateTrainingProgramUserRequest {
  constructor(data: Partial<CreateTrainingProgramUserRequest>) {
    Object.assign(this, data);
  }

  userId: string;
  programId: string;
  startDate: Date;
}
