import { AccountType } from 'src/server-models/enums/account-type.enum';
import { CreateUserRequest } from './../../server-models/cqrs/users/requests/create-user.request';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { UpdateUserRequest } from 'src/server-models/cqrs/users/requests/update-user.request';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { UserSettings } from 'src/server-models/entities/user-settings.model';
import { BaseService } from './base.service';

@Injectable({ providedIn: 'root'})
export class UsersService extends BaseService {
    private url = '/Users/';

    constructor(
        private http: HttpClient,
    ) {
        super();
    }


    public getAll() {
        return this.http.get<ApplicationUser[]>(this.url + 'GetAll')
            .pipe(
                catchError(this.handleError)
            );
    }

    public getOne(userId: string) {
        return this.http.get<ApplicationUser>(this.url + 'Get/' + userId)
            .pipe(
                catchError(this.handleError)
            );
    }

    public create(request: CreateUserRequest) {
        return this.http.post<ApplicationUser>(this.url + 'Create/', request)
        .pipe(
            catchError(this.handleError)
        );
    }

    public update(command: UpdateUserRequest) {
        return this.http.post<void>(this.url + 'Update/', command)
            .pipe(
                catchError(this.handleError)
            );
    }

    public delete() {

    }

    public changePassword() {

    }

    public saveSettings(userSettings: UserSettings) {
        const payload = { userSettings: userSettings };
        return this.http.post(this.url + 'SaveUserSettings/', payload)
            .pipe(
                catchError(this.handleError)
            );
    }


}
