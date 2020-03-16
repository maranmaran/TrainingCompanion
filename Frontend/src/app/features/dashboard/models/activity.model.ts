export interface Activity {
  userId: string;
  userName: string;
  type: ActivityType;
  date: Date;
  message: string;
}

export enum ActivityType {
  Training = "Training",
  MediaFile = "MediaFile",
  Bodyweight = "Bodyweight",
  PersonalBest = "PersonalBest"
}

