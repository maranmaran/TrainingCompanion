export class ExportRequest {
  userId: string;
  fromDate: Date;
  toDate: Date;
  all: boolean;
}

export class ExportExerciseTypeRequest extends ExportRequest {
}

export class ExportTrainingRequest extends ExportRequest {
}