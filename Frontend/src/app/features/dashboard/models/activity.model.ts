export class Activity {
  userId: string;
  userName: string;
  type: ActivityType;
  date: Date;
  message: string;
  jsonEntity: string;
  entity: string;
}

export enum ActivityType {
  Training = "Training",
  MediaFile = "MediaFile",
  Bodyweight = "Bodyweight",
  PersonalBest = "PersonalBest"
}
