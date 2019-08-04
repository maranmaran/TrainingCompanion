import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { UpdateUserRequest } from 'src/server-models/cqrs/users/requests/update-user.request';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { UserSettings } from 'src/server-models/entities/user-settings.model';
import { BaseService } from './base.service';

@Injectable()
export class SubusersService extends BaseService {
    private url = '/Subusers/';

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

    public getAllByUserId(userId: string) {
        return this.http.get<ApplicationUser[]>(this.url + 'GetAllByUserId/' + userId)
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

    public create() {
        // return this.http.get<ApplicationUser>(this.url + 'Get/' + userId)
        // .pipe(
        //     map((res: ApplicationUser) => this.userAdapter.adaptToModel(res)),
        //     catchError(this.handleError)
        // );
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
