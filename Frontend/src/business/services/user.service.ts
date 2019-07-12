import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map } from 'rxjs/operators';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { ApplicationUserAdapter } from '../adapters/application-user.adapter';
import { UpdateUserCommand } from './../../server-models/cqrs/users/commands/update-user.command';
import { BaseService } from './base.service';

@Injectable({ providedIn: 'root'})
export class UsersService extends BaseService {
    private url = '/Users/';

    constructor(
        private http: HttpClient,
        private userAdapter: ApplicationUserAdapter
    ) {
        super();
    }


    public getAll() {
        return this.http.get<ApplicationUser[]>(this.url + 'GetAll')
            .pipe(
                map((res: ApplicationUser[]) => this.userAdapter.adaptToList(res)),
                catchError(this.handleError)
            );
    }

    public getOne(userId: string) {
        return this.http.get<ApplicationUser>(this.url + 'Get/' + userId)
            .pipe(
                map((res: ApplicationUser) => this.userAdapter.adaptToModel(res)),
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

    public update(command: UpdateUserCommand) {
        return this.http.post<void>(this.url + 'Update/', command)
            .pipe(
                catchError(this.handleError)
            );
    }

    public delete() {

    }

    public changePassword() {

    }

    public saveSettings(user: CurrentUser) {
        const payload = { id: user.id, userSettings: user.userSettings };
        return this.http.post(this.url + 'SaveUserSettings/', payload)
            .pipe(
                catchError(this.handleError)
            );
    }


}
