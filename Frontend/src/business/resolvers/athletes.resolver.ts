import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { athletesFetched } from 'src/ngrx/athletes/athlete.actions';
import { athletes } from 'src/ngrx/athletes/athlete.selectors';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { AccountType } from 'src/server-models/enums/account-type.enum';
import { currentUser } from '../../ngrx/auth/auth.selectors';
import { UserService } from '../services/feature-services/user.service';
import { setActiveProgressBar } from 'src/ngrx/user-interface/ui.actions';
import { UIProgressBar } from '../shared/ui-progress-bars.enum';

@Injectable()
export class AthletesResolver implements Resolve<Observable<ApplicationUser[] | void>> {

    constructor(
        private userService: UserService,
        private store: Store<AppState>
    ) { }


    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {

        return this.store.select(currentUser)
            .pipe(
                take(1), 
                map((user: CurrentUser) => user.id),
                concatMap((userId: string) => {
                    return this.getState(userId);
                }));
    }

    private getState(userId: string) {

        return this.store
            .select(athletes)
            .pipe(
                take(1), 
                concatMap((athletes: ApplicationUser[]) => {

                if (!athletes) {
                    return this.updateState(userId);
                }
                        
                return of(athletes);
            }));
    }

    private updateState(userId: string) {

        return this.userService.getAll(AccountType.Athlete, userId)
        .pipe(
            take(1),
            map((athletes: ApplicationUser[]) => {
                this.store.dispatch(athletesFetched({athletes}));
            })
        );
    }
}

