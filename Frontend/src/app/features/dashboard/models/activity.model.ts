
export class BasicUserInfo {
  userId: string;
  userAvatar: string;
  userName: string;
}

export class BasicActivityInfo {
  id: string;
  type: ActivityType;
  date: Date;
  message: string;
  jsonEntity: string;
  seen: boolean;
  entity: any;
}

export class Activity {
  userInfo: BasicUserInfo;
  activityInfo: BasicActivityInfo;
}

export class UserActivitiesContainer {
  userId: string;
  userAvatar: string;
  userName: string;
  unseenActivities: number;
  activities: BasicActivityInfo[];
}

export enum ActivityType {
  Training = "Training",
  MediaFile = "MediaFile",
  Bodyweight = "Bodyweight",
  PersonalBest = "PersonalBest"
}
