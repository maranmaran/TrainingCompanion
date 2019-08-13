import { AccountType } from 'src/server-models/enums/account-type.enum';
import { Gender } from 'src/server-models/enums/gender.enum';

export class UpdateUserRequest {
    accountType: AccountType;
    id: string;
    username: string;
    email: string;
    firstname: string;
    lastname: string;
    gender: Gender;
    active: boolean;
}