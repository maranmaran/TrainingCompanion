import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { athletesFetched } from 'src/ngrx/athletes/athlete.actions';
import { athletes } from 'src/ngrx/athletes/athlete.selectors';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { AthletesService } from '../services/athletes.service';
import { currentUser } from '../../ngrx/auth/auth.selectors';

@Injectable()
export class AthletesResolver implements Resolve<Observable<ApplicationUser[] | void>> {

    constructor(
        private athletesService: AthletesService,
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

        return this.athletesService.getAllByCoachId(userId)
        .pipe(
            take(1),
            map((athletes: ApplicationUser[]) => {
                this.store.dispatch(athletesFetched({athletes}));
            })
        );
    }
}

