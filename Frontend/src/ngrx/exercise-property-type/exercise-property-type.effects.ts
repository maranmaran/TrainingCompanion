import { exercisePropertyTypes } from './exercise-property-type.selectors';
import { Store } from '@ngrx/store';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import * as ExercisePropertyTypeActions from './exercise-property-type.actions';
import { AppState } from 'src/ngrx/global-setup.ngrx';
import { tap, switchMap, map } from 'rxjs/operators';


@Injectable()
export class ExercisePropertyTypeEffects {

    constructor(
        private actions$: Actions,
        private store: Store<AppState>
    ) { }

    reorder$ = createEffect(() =>
        this.actions$
            .pipe(
                ofType(ExercisePropertyTypeActions.reorderExercisePropertyTypes),
                switchMap(() => this.store.select(exercisePropertyTypes)),
                map((propertyTypes) => {
                  this.store.dispatch(ExercisePropertyTypeActions.updateManyExercisePropertyType({propertyTypes}))
                })
            )
        , { dispatch: false });

}
