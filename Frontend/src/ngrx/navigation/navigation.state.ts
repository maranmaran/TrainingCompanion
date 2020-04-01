export enum BottomNavigation {
  Main = 0,
  Chat = 1,
  Dashboard = 2,
  TrainingLog = 3,
  BodyweightLog = 4
}

export interface NavigationState {
  // athlete routes and navigation (tabs)
  activeNavigation: BottomNavigation,
  activeTab: number;
  previousRoute: string;
}

export const navigationInitialState: NavigationState = {
  activeNavigation: BottomNavigation.Main,
  activeTab: 0,
  previousRoute: undefined
}



