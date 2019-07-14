import { AccountStatus } from 'src/server-models/enums/account-status.enum';
export class UpdateUserRequest {
    id: string;
    username: string;
    email: string;
    firstname: string;
    lastname: string;
    accountStatus: AccountStatus;

    constructor(
        id: string,
        username: string,
        email: string,
        firstname: string,
        lastname: string,
        accountStatus: AccountStatus,
    ) {
        this.id = id;
        this.username = username;
        this.email = email;
        this.firstname = firstname;
        this.lastname = lastname;
        this.accountStatus = accountStatus;
        
    }
}