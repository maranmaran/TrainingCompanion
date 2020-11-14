import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { tap, withLatestFrom } from 'rxjs/operators';
import { setLatestBodyweight } from '../auth/auth.actions';
import { AppState } from '../global-setup.ngrx';
import { Bodyweight } from './../../server-models/entities/bodyweight.model';
import { latestBodyweight } from './../auth/auth.selectors';
import * as BodyweightActions from './bodyweight.actions';

@Injectable()
export class BodyweightEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>
    ) { }


    onBodyweightUpdatedOrCreated$ = createEffect(() =>
    this.actions$
        .pipe(
            ofType(BodyweightActions.bodyweightCreated, BodyweightActions.bodyweightUpdated),
            withLatestFrom(this.store.select(latestBodyweight)),
            tap(([newBodyweightRaw, currentlatestBodyweight]) => {
              const castedBodyweight = newBodyweightRaw as unknown as { entity: Bodyweight };

              if(!castedBodyweight?.entity) {
                return;
              }

              if( !currentlatestBodyweight || castedBodyweight.entity.date >= currentlatestBodyweight.date) {
                this.store.dispatch(setLatestBodyweight({bodyweight: castedBodyweight.entity }));
              }
            })
        )
    , { dispatch: false });
}
