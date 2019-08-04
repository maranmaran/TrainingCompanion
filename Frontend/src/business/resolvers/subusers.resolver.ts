import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Store } from '@ngrx/store';
import { Observable, of } from 'rxjs';
import { concatMap, map, take } from 'rxjs/operators';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { subusersFetched } from 'src/ngrx/subusers/subuser.actions';
import { subusers } from 'src/ngrx/subusers/subuser.selectors';
import { CurrentUser } from 'src/server-models/cqrs/authorization/responses/current-user.response';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { SubusersService } from '../services/subusers.service';
import { currentUser } from '../../ngrx/auth/auth.selectors';

@Injectable()
export class SubusersResolver implements Resolve<Observable<ApplicationUser[] | void>> {

    constructor(
        private subusersService: SubusersService,
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
            .select(subusers)
            .pipe(
                take(1), 
                concatMap((subusers: ApplicationUser[]) => {

                if (!subusers) {
                    return this.updateState(userId);
                }
                        
                return of(subusers);
            }));
    }

    private updateState(userId: string) {

        return this.subusersService.getAllByUserId(userId)
        .pipe(
            take(1),
            map((subusers: ApplicationUser[]) => {
                this.store.dispatch(subusersFetched({subusers}));
            })
        );
    }
}

