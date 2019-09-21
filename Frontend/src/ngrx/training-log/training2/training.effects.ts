import { Injectable, enableProdMode } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Store } from '@ngrx/store';
import { tap } from 'rxjs/operators';
import { LocalStorageKeys } from 'src/business/shared/localstorage.keys.enum';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { normalizeTrainingArray } from '../training-log.normalizer';
import * as ExerciseActions from './../exercise/exercise.actions';
import * as SetActions from './../set/set.actions';
import * as TrainingActions from '../training/training.actions';
import { CRUD } from 'src/business/shared/crud.enum';

@Injectable()
export class TrainingEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>
    ) { }


}
