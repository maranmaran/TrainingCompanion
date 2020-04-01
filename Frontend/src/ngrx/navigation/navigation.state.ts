export enum AthleteBottomNavigation {
  Main = 0,
  Chat = 1,
  Dashboard = 2,
  TrainingLog = 3,
  BodyweightLog = 4
}

export interface NavigationState {
  // athlete routes and navigation (tabs)
  athleteActiveNavigation: AthleteBottomNavigation,
  athleteActiveTabIdx: number;
  athletePreviousRoute: string;
}

export const navigationInitialState: NavigationState = {
  athleteActiveNavigation: AthleteBottomNavigation.Main,
  athleteActiveTabIdx: 0,
  athletePreviousRoute: undefined
}



