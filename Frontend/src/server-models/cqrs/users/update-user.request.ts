import { AccountType } from 'src/server-models/enums/account-type.enum';
import { Gender } from 'src/server-models/enums/gender.enum';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';

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

export function GetUpdateUserRequest(user: ApplicationUser) {

    var request = new UpdateUserRequest();
    request.accountType = user.accountType;
    request.id = user.id;
    request.username = user.username;
    request.email = user.email;
    request.firstname = user.firstName;
    request.lastname = user.lastName;
    request.gender = user.gender;
    request.active = user.active;

    return request;
}