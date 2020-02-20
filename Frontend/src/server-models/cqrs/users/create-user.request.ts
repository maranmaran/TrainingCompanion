import { AccountType } from 'src/server-models/enums/account-type.enum';
import { Gender } from 'src/server-models/enums/gender.enum';
export class CreateUserRequest {
    accountType: AccountType;
    username: string;
    email: string;
    firstname: string;
    lastname: string;
    gender: Gender;
    coachId: string;

    constructor() {
    }
   
}