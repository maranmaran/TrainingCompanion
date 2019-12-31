export class ImportRequest {
  userId: string;
  file: File;
}

export class ImportExerciseTypeRequest extends ImportRequest {
}

export class ImportTrainingRequest extends ImportRequest {
}