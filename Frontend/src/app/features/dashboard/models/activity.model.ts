
export class Activity {
  userId: string;
  userAvatar: string;
  userName: string;
  type: ActivityType;
  date: Date;
  message: string;
  jsonEntity: string;
  entity: any;
}

export enum ActivityType {
  Training = "Training",
  MediaFile = "MediaFile",
  Bodyweight = "Bodyweight",
  PersonalBest = "PersonalBest"
}
