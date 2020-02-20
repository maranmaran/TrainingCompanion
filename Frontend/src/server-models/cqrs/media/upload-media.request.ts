
export class UploadMediaRequest {
  userId: string;
  file: File;
  extension: string;
  type: string;
}

export class UploadTrainingMediaRequest extends UploadMediaRequest {
  trainingId: string;
}

export class UploadExerciseMediaRequest extends UploadMediaRequest {
exerciseId: string;
}