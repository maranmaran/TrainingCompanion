import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { UserSettings } from 'src/server-models/entities/user-settings.model';
import { AccountType } from 'src/server-models/enums/account-type.enum';
import { CrudService } from '../crud.service';


@Injectable({ providedIn: 'root'})
export class UserService extends CrudService<ApplicationUser> {

    constructor(
        private httpDI: HttpClient,
    ) {
        super(httpDI, "Users");
    }

    public getAll(accountType?: AccountType, coachId?: string) {
        return this.http.get<ApplicationUser[]>(this.url + 'GetAll/' + accountType + '/' + coachId)
            .pipe(
                catchError(this.handleError)
            );
    }

    public getOne(id?: string, accountType?: AccountType) {
        return this.http.get<ApplicationUser>(this.url + 'Get/' + id + '/' + accountType)
            .pipe(
                catchError(this.handleError)
            );
    }

    public delete(id: string, accountType?: AccountType) {
        return this.http.get(this.url + 'Delete/' + id + '/' + accountType)
            .pipe(
                catchError(this.handleError)
            );
    }

    public setActive(id: string, active: boolean) {
        return this.http.get(this.url + 'SetActive/' + id + '/' + active)
            .pipe(
                catchError(this.handleError)
            );
    }

    public saveSettings(userSettings: UserSettings) {
        const payload = { userSettings: userSettings };
        return this.http.post(this.url + 'SaveUserSettings/', payload)
            .pipe(
                catchError(this.handleError)
            );
    }

}
