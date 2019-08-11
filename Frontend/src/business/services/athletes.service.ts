import { UpdateAthleteRequest } from './../../server-models/cqrs/athletes/requests/update-athlete.request';
import { CreateAthleteRequest } from '../../server-models/cqrs/athletes/requests/create-athlete.request';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError } from 'rxjs/operators';
import { UpdateUserRequest } from 'src/server-models/cqrs/users/requests/update-user.request';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { UserSettings } from 'src/server-models/entities/user-settings.model';
import { BaseService } from './base.service';

@Injectable()
export class AthletesService extends BaseService {
    
    private url = '/Athlete/';

    constructor(
        private http: HttpClient,
    ) {
        super();
    }

    public getAllByCoachId(coachId: string) {
        return this.http.get<ApplicationUser[]>(this.url + 'GetAllByCoachId/' + coachId)
            .pipe(
                catchError(this.handleError)
            );
    }

    
    public setActive(athleteId: string, value: boolean) {
        return this.http.get(this.url + 'setActive/' + athleteId + '/' + value)
            .pipe(
                catchError(this.handleError)
            );
    }

    public create(request: CreateAthleteRequest) {
        return this.http.post<ApplicationUser>(this.url + 'Create/', request)
        .pipe(
            catchError(this.handleError)
        );
    }
    
    public update(request: UpdateAthleteRequest) {
        return this.http.post<ApplicationUser>(this.url + 'Update/', request)
        .pipe(
            catchError(this.handleError)
        );
    }
    
    public delete(id: string) {
        return this.http.get(this.url + 'Delete/' + id)
        .pipe(
            catchError(this.handleError)
        );
    }
}
