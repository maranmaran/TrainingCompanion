import { createAction, props } from '@ngrx/store';
import { BottomNavigation } from './navigation.state';

export const setActiveNavigation = createAction('[Navigation - Athlete] Set active navigation', props<{ nav: BottomNavigation }>());
export const setActiveTab = createAction('[Navigation - Athlete] Set active tab', props<{ tab: number }>());
export const setPreviousRoute = createAction('[Navigation - Athlete] Set previous route', props<{ route: string }>());
