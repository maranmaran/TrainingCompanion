import { combineLatest } from 'rxjs/internal/observable/combineLatest';
import { ApplicationUser } from 'src/server-models/entities/application-user.model';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { UserService } from 'src/business/services/feature-services/user.service';
import { AppState } from '../global-setup.ngrx';
import { map, concatMap, mergeMap, combineAll } from 'rxjs/operators';
import * as AthleteActions from './athlete.actions';
import { selectedAthlete } from './athlete.selectors';
import { forkJoin } from 'rxjs';

@Injectable()
export class AthletesEffects {

    constructor(
        private actions$: Actions,
        private userService: UserService,
        private store: Store<AppState>
    ) { }


    // fetchAthletes$ = createEffect(() =>
    //     this.actions$
    //         .pipe(
    //             ofType(AthleteActions.getAllAthlete),
    //             switchMap((request: { userId: string }) => {
    //                 return this.userService.getAll(AccountType.Athlete, request.userId)
    //             }),
    //             map((athletes: ApplicationUser[]) => {
    //                 return this.store.dispatch(AthleteActions.athletesFetched({athletes}))
    //             })
    //         )
    //     , { dispatch: false });

}
