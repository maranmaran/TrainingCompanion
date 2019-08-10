import { AccountType } from 'src/server-models/enums/account-type.enum';
import { Gender } from 'src/server-models/enums/gender.enum';

export class CreateAthleteRequest {
    coachId: string;
    username: string;
    email: string;
    firstname: string;
    lastname: string;
    accountType: AccountType;
    password: string;
    confirmPassword: string;
    gender: Gender;
}

