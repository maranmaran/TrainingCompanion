import { Gender } from 'src/server-models/enums/gender.enum';

export class UpdateAthleteRequest {
    id: string;
    username: string;
    email: string;
    firstname: string;
    lastname: string;
    fullName: string;
    gender: Gender;
    active: boolean;
}