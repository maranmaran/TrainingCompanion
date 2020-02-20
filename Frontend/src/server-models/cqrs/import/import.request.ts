
export class ImportRequest {
  userId: string;
  file: File;
}

export class ImportExerciseTypeRequest extends ImportRequest {

  constructor(userId: string, file: File) {
    super();
    this.userId = userId;
    this.file = file;
  }
}

export class ImportTrainingRequest extends ImportRequest {
  constructor(userId: string, file: File) {
    super();
    this.userId = userId;
    this.file = file;
  }
}
