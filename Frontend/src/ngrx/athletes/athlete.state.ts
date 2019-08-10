import { ApplicationUser } from '../../server-models/entities/application-user.model';

export interface AthletesState {
    athletes: ApplicationUser[];
    selected: ApplicationUser;
}

export const initialAthletesState: AthletesState = {
    athletes: undefined,
    selected: undefined
};
