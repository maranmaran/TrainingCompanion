import { createAction, props } from '@ngrx/store';
import { AthleteBottomNavigation } from './navigation.state';

export const athleteActiveBottomNav = createAction('[Navigation - Athlete] Set active nav', props<{ nav: AthleteBottomNavigation }>());
export const athleteActiveTab = createAction('[Navigation - Athlete] Set active tab', props<{ tab: number }>());
export const athletePreviousRoute = createAction('[Navigation - Athlete] Set previous route', props<{ route: string }>());
