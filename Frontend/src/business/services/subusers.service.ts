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

    public getAllByUserId(userId: string) {
        return this.http.get<ApplicationUser[]>(this.url + 'GetAllByUserId/' + userId)
            .pipe(
                catchError(this.handleError)
            );
    }

    
    public setActive(userId: string, value: boolean) {
        return this.http.get(this.url + 'setActive/' + userId + '/' + value)
            .pipe(
                catchError(this.handleError)
            );
    }

    // public register(userId: string, value: boolean) {
    //     return this.http.get<ApplicationUser>(this.url + 'register/' + userId + '/' + value)
    //         .pipe(
    //             catchError(this.handleError)
    //         );
    // }

}
