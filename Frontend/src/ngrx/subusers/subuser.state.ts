import { ApplicationUser } from '../../server-models/entities/application-user.model';

export interface SubusersState {
    subusers: ApplicationUser[];
}

export const initialSubusersState: SubusersState = {
    subusers: undefined,
};
