export class SetPasswordRequest {

    userId: string;
    password: string;
    repeatPassword: string;

    constructor(userId: string, password: string, repeatPassword: string) {
        this.userId = userId;
        this.password = password;
        this.repeatPassword = repeatPassword;
    }
}