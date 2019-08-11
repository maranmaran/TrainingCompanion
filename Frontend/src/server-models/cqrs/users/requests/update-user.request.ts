export class UpdateUserRequest {
    id: string;
    username: string;
    email: string;
    firstname: string;
    lastname: string;
    active: boolean;

    constructor(
        id: string,
        username: string,
        email: string,
        firstname: string,
        lastname: string,
        active: boolean,
    ) {
        this.id = id;
        this.username = username;
        this.email = email;
        this.firstname = firstname;
        this.lastname = lastname;
        this.active = active;
        
    }
}